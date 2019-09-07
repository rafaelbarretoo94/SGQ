using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;

namespace IncidentesProblemasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NaoConformidadeController : ControllerBase
    {
        private readonly INaoConformidadeService _naoConformidadeService;

        public NaoConformidadeController(
            INaoConformidadeService naoConformidadeService)
        {
            _naoConformidadeService = naoConformidadeService;
        }

        // GET: api/NaoConformidade
        [HttpGet]
        public IEnumerable<NaoConformidade> Get()
        {
            return _naoConformidadeService.SelecionarTodos();
        }

        // POST: api/NaoConformidade
        [HttpPost]
        public void Post([FromBody] NaoConformidade naoConformidade)
        {
            _naoConformidadeService.Adicionar(naoConformidade);
        }
    }
}
