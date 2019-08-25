using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Service.Interfaces;

namespace SGQ.Application.Controllers
{
    public class AtividadeController : BaseController
    {
        private readonly IAtividadeService atividadeService;

        public AtividadeController(IAtividadeService _atividadeService)
        {
            atividadeService = _atividadeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(AtividadeModel atividade)
        {
            if(ModelState.IsValid)
            {
                atividadeService.Adicionar(AtividadeModel.ConverterViewParaEntity(atividade));
            }
            return View(atividade);
        }
    }
}