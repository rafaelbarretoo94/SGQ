using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Service.Interfaces;

namespace SGQ.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : BaseController
    {
        private readonly IProcessoService _processoService;

        public ProcessoController(IMapper mapper, IProcessoService processoService) : base(mapper)
        {
            _processoService = processoService;
        }

        // GET: api/Processo
        [HttpGet]
        public IEnumerable<ProcessoModel> Get()
        {
            return Index();
        }

        // GET: api/Processo/5
        [HttpGet("{id}", Name = "Get")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/Processo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Processo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public IEnumerable<ProcessoModel> Index()
        {
            var processos = _processoService.SelecionarTodos();
            return _mapper.Map<IEnumerable<ProcessoModel>>(processos);
        }

    }
}
