using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class ProcessoController : BaseController
    {
        private readonly IProcessoService _processoService;
        private readonly IEnumBaseService _enumBaseService;

        public ProcessoController(IMapper mapper,
            IProcessoService processoService,
            IEnumBaseService enumBaseService) : base(mapper)
        {
            _processoService = processoService;
            _enumBaseService = enumBaseService;
        }

        public IActionResult Index()
        {
            IEnumerable<Processo> listProcessos = _processoService.SelecionarTodos();
            IEnumerable<ProcessoViewModel> listProcessoViewModel = _mapper.Map<IEnumerable<Processo>, IEnumerable<ProcessoViewModel>>(listProcessos);
            return View(listProcessoViewModel);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            CarregarViewBags();
            return View();
        }

        public void CarregarViewBags()
        {
            IEnumerable<EnumBase> listPeriodicidadeProcesso = _enumBaseService.ObterEnumBasePorTipo("PeriodicidadeVerificacaoProcesso");
            IEnumerable<EnumBase> listStatusProcesso = _enumBaseService.ObterEnumBasePorTipo("StatusProcesso");

            ViewBag.lstPeriodicidadeVerificacaoProcesso = listPeriodicidadeProcesso.Select(x => new { x.Id, x.Valor }).ToList();
            ViewBag.lstStatusProcesso = listStatusProcesso.Select(x => new { x.Id, x.Valor }).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcessoViewModel processo)
        {
            if (ModelState.IsValid)
            {
                var entityProcesso = _mapper.Map<Processo>(processo);
                var usuarioAtualId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                entityProcesso.UsuarioCadastroId = usuarioAtualId;
                entityProcesso.UsuarioModificacaoId = usuarioAtualId;

                _processoService.Adicionar(entityProcesso);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}