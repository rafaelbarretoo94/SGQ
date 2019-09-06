using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using SGQ.Service.Services;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class NaoConformidadeController : BaseController
    {
        private readonly INaoConformidadeService _naoConformidadeService;
        private readonly IEnumBaseService _enumBaseService;
        private readonly IProcessoService _processoService;
        private readonly IUsuarioService _usuarioService;

        public NaoConformidadeController(IMapper mapper,
            INaoConformidadeService naoConformidadeService,
            IEnumBaseService enumBaseService,
            IProcessoService processoService,
            IUsuarioService usuarioService) : base(mapper)
        {
            _naoConformidadeService = naoConformidadeService;
            _enumBaseService = enumBaseService;
            _processoService = processoService;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var listNaoConformidades = _naoConformidadeService.SelecionarTodos();
            IEnumerable<NaoConformidadeViewModel> listNaoConformidadeViewModel = _mapper.Map<IEnumerable<NaoConformidade>, IEnumerable<NaoConformidadeViewModel>>(listNaoConformidades);
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
                _naoConformidadeService.Adicionar(entityNaoConformidade);
                return RedirectToAction("Index");
            }

            CarregarViewBags();
            return View(naoConformidade);
        }

        public void CarregarViewBags()
        {
            var listTipoNaoConformidade = _enumBaseService.ObterEnumBasePorTipo("TipoNaoConformidade");
            var listProcessos = _processoService.SelecionarTodos();
            var listUsuarios = _usuarioService.SelecionarTodos();

            ViewBag.lstTipoNaoConformidade = listTipoNaoConformidade.Select(x => new { x.Id, x.Valor });
            ViewBag.lstProcessos = listProcessos.Select(x => new { x.Id, x.Nome });
            ViewBag.lstUsuarios = listUsuarios.Select(x => new { x.Id, x.UserName });
        }

    }
}