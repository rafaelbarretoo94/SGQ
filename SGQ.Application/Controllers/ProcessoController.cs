using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<EnumBase> listPeriodicidadeProcesso = _enumBaseService.ObterEnumBasePorTipo("PeriodicidadeVerificacaoProcesso");
            IEnumerable<EnumBase> listStatusProcesso = _enumBaseService.ObterEnumBasePorTipo("StatusProcesso");

            ViewBag.lstPeriodicidadeVerificacaoProcesso = listPeriodicidadeProcesso.Select(x => new { x.Id, x.Valor }).ToList();
            ViewBag.lstStatusProcesso = listStatusProcesso.Select(x => new { x.Id, x.Valor }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcessoViewModel processo)
        {
            if (ModelState.IsValid)
            {
                _processoService.Adicionar(_mapper.Map<Processo>(processo));
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Processo/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Processo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _processoService.Atualizar(_mapper.Map<Processo>(collection));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Processo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Processo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _processoService.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}