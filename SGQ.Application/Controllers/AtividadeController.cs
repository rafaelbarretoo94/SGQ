using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class AtividadeController : BaseController
    {
        private readonly IAtividadeService _atividadeService;
        private readonly IProcessoService _processoService;

        public AtividadeController(IMapper mapper, 
            IAtividadeService atividadeService,
            IProcessoService processoService, 
            IConfiguration config) : base(mapper, config)
        {
            _processoService = processoService;
            _atividadeService = atividadeService;
        }

        public IActionResult Index()
        {

            IEnumerable<Atividade> listAtividades = _atividadeService.SelecionarTodos();
            IEnumerable<AtividadeViewModel> listAtividadeViewModel = _mapper.Map<IEnumerable<Atividade>, IEnumerable<AtividadeViewModel>>(listAtividades);
         
            foreach (var atividadeViewModel in listAtividadeViewModel)
            {
                atividadeViewModel.NomeUsuarioCadastro = listAtividades
                    .Where(x => x.Id == atividadeViewModel.Id)
                    .Select(y => y.UsuarioCadastro.Email).FirstOrDefault();

                atividadeViewModel.NomeUsuarioModificacao = listAtividades
                    .Where(x => x.Id == atividadeViewModel.Id)
                    .Select(y => y.UsuarioModificacao.Email).FirstOrDefault();
            }

            return View(listAtividadeViewModel);
        }

        public IActionResult Create()
        {
            var listProcessos = _processoService.SelecionarTodos();
            ViewBag.lstProcessos = listProcessos.Select(x => new { x.Id, x.Nome });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AtividadeViewModel atividade)
        {
            if (ModelState.IsValid)
            {
                var entityAtividade = _mapper.Map<Atividade>(atividade);
                var usuarioAtualId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                entityAtividade.UsuarioCadastroId = usuarioAtualId;
                entityAtividade.UsuarioModificacaoId = usuarioAtualId;
                _atividadeService.Adicionar(entityAtividade);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}