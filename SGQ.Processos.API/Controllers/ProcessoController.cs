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
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoService _processoService;

        public ProcessoController(IProcessoService processoService)
        {
            _processoService = processoService;
        }
        // GET: api/Processo
        [HttpGet]
        public IEnumerable<Processo> Get()
        {
            return _processoService.SelecionarTodos();
        }

        // POST: api/Processo
        [HttpPost]
        public void Post([FromBody] Processo processo)
        {
            _processoService.Adicionar(processo);
        }
    }
}
