using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class AtividadeController : BaseController
    {
        private readonly IAtividadeService atividadeService;

        public AtividadeController(IMapper mapper, IAtividadeService _atividadeService) : base(mapper)
        {
            atividadeService = _atividadeService;
        }

        public IActionResult Index()
        {
            var listAtividades = atividadeService.SelecionarTodos();
            return View(_mapper.Map<IEnumerable<AtividadeViewModel>>(listAtividades));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AtividadeViewModel atividade)
        {
            if (ModelState.IsValid)
            {
                atividadeService.Adicionar(_mapper.Map<Atividade>(atividade));
            }
            return RedirectToAction("Index");
        }
    }
}