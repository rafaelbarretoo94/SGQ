using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;

namespace ProcessosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        // GET: api/Atividade
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _atividadeService.SelecionarTodos();
        }

        // POST: api/Atividade
        [HttpPost]
        public void Post([FromBody] Atividade atividade)
        {
            _atividadeService.Adicionar(atividade);
        }
    }
}
