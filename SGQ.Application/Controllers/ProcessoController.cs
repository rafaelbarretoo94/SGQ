using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using System.Collections.Generic;

namespace SGQ.Application.Controllers
{
    public class ProcessoController : BaseController
    {

        private readonly IProcessoService _processoService;

        public ProcessoController(IMapper mapper, IProcessoService processoService) : base(mapper)
        {

            _processoService = processoService;

        }
        // GET: Processo
        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<ProcessoModel>>(_processoService.SelecionarTodos()));
        }

        // GET: Processo/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Processo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _processoService.Adicionar(_mapper.Map<Processo>(collection));
                }
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
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