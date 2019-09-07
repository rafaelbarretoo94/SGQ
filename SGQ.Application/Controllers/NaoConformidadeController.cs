using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using SGQ.Service.Services;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class NaoConformidadeController : BaseController
    {
        private readonly IEnumBaseService _enumBaseService;
        private readonly IUsuarioService _usuarioService;
        private readonly string _apiProcessos = "https://localhost:44334/api/processo";
        private readonly string _api = "https://localhost:44353/api/naoconformidade";

        public NaoConformidadeController(IMapper mapper,
            IEnumBaseService enumBaseService,
            IUsuarioService usuarioService, 
            IConfiguration config) : base(mapper, config)
        {
            _enumBaseService = enumBaseService;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var resultTask = ClientGetAsync(_api);
            resultTask.Wait();

            var listNaoConformidades = JsonConvert.DeserializeObject<List<NaoConformidade>>(resultTask.Result);
            IEnumerable<NaoConformidadeViewModel> listNaoConformidadeViewModel = _mapper.Map<IEnumerable<NaoConformidade>, IEnumerable<NaoConformidadeViewModel>>(listNaoConformidades);

            foreach (var naoConformidadeViewModel in listNaoConformidadeViewModel)
            {
                naoConformidadeViewModel.NomeUsuarioCadastro = listNaoConformidades
                    .Where(x => x.Id == naoConformidadeViewModel.Id)
                    .Select(y => y.UsuarioCadastro.Email).FirstOrDefault();

                naoConformidadeViewModel.NomeUsuarioModificacao = listNaoConformidades
                    .Where(x => x.Id == naoConformidadeViewModel.Id)
                    .Select(y => y.UsuarioModificacao.Email).FirstOrDefault();
            }

            return View(_mapper.Map<IEnumerable<NaoConformidadeViewModel>>(listNaoConformidadeViewModel));
        }

        public IActionResult Create()
        {
            CarregarViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NaoConformidadeViewModel naoConformidade)
        {
            if (ModelState.IsValid)
            {
                var entityNaoConformidade = _mapper.Map<NaoConformidade>(naoConformidade);
                var usuarioAtualId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                entityNaoConformidade.UsuarioCadastroId = usuarioAtualId;
                entityNaoConformidade.UsuarioModificacaoId = usuarioAtualId;

                string jsonContent = JsonConvert.SerializeObject(entityNaoConformidade);
                var resultTask = ClientPostAsync(_api, jsonContent);
                return RedirectToAction("Index");
            }

            CarregarViewBags();
            return View(naoConformidade);
        }

        public void CarregarViewBags()
        {
            var resultTask = ClientGetAsync(_apiProcessos);
            resultTask.Wait();

            var listProcessos = JsonConvert.DeserializeObject<List<Processo>>(resultTask.Result);
            var listTipoNaoConformidade = _enumBaseService.ObterEnumBasePorTipo("TipoNaoConformidade");
            var listUsuarios = _usuarioService.SelecionarTodos();

            ViewBag.lstTipoNaoConformidade = listTipoNaoConformidade.Select(x => new { x.Id, x.Valor });
            ViewBag.lstProcessos = listProcessos.Select(x => new { x.Id, x.Nome });
            ViewBag.lstUsuarios = listUsuarios.Select(x => new { x.Id, x.UserName });
        }

    }
}