using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using SGQ.Service.Services;

namespace SGQ.Application.Controllers
{
    public class NaoConformidadeController : BaseController
    {

        private readonly INaoConformidadeService _naoConformidadeService;

        public NaoConformidadeController(IMapper mapper, INaoConformidadeService naoConformidadeService):base(mapper)
        {
            _naoConformidadeService = naoConformidadeService;

        }
        // GET: NaoConformidade
        public IActionResult Index()
        {
            var listAtividades = _naoConformidadeService.SelecionarTodos();
            return View(_mapper.Map<IEnumerable<NaoConformidadeModel>>(listAtividades));            
        }

        // GET: NaoConformidade/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: NaoConformidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaoConformidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _naoConformidadeService.Adicionar(_mapper.Map<NaoConformidade>(collection));
                }
                return RedirectToAction("Index");                
            }
            catch
            {
                return View();
            }
        }

        // GET: NaoConformidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NaoConformidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _naoConformidadeService.Atualizar(_mapper.Map<NaoConformidade>(collection));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NaoConformidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NaoConformidade/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _naoConformidadeService.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}