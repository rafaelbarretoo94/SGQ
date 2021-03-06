﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;

namespace SGQ.Application.Controllers
{
    [Authorize]
    public class AtividadeController : BaseController
    {
        private readonly string _apiProcessos;
        private readonly string _api;

        public AtividadeController(IMapper mapper, IConfiguration config) : base(mapper, config)
        {
            _api = config["ProcessosApiAtividadeEndpoint"];
            _apiProcessos = config["ProcessosApiEndpoint"];
        }

        public IActionResult Index()
        {
            var resultTask = ClientGetAsync(_api);
            resultTask.Wait();

            IEnumerable<Atividade> listAtividades = JsonConvert.DeserializeObject<List<Atividade>>(resultTask.Result);
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
            var resultTask = ClientGetAsync(_apiProcessos);
            resultTask.Wait();

            var listProcessos = JsonConvert.DeserializeObject<List<Processo>>(resultTask.Result);
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

                string jsonContent = JsonConvert.SerializeObject(entityAtividade);
                var resultTask = ClientPostAsync(_api, jsonContent);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}