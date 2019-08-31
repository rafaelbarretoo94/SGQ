using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGQ.Application.Models;
using SGQ.Domain.Entities;
using SGQ.Service.Interfaces;
using System.Collections.Generic;

namespace SGQ.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NaoConformidadeController : BaseController
    {
        private readonly INaoConformidadeService _naoConformidadeService;
        public NaoConformidadeController(IMapper mapper, INaoConformidadeService naoConformidadeService) : base(mapper)
        {
            _naoConformidadeService = naoConformidadeService;
        }

        // GET: api/NaoConformidade
        [HttpGet]
        public ActionResult Get()
        {
            return View("Index", Index());
        }

        // GET: api/NaoConformidade/5
        [HttpGet("{id}", Name = "GetById")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/NaoConformidade
        [HttpPost(Name ="Create")] 
        public IActionResult Create()
        {
            return View(); 
        }

        // PUT: api/NaoConformidade/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public ActionResult CreateNaoConformidade([FromBody] NaoConformidadeModel naoConformidadeModel)
        {

            if (ModelState.IsValid)
            {
                _naoConformidadeService.Adicionar(_mapper.Map<NaoConformidade>(naoConformidadeModel));
            }
            return RedirectToAction("Index");

        }


        public IEnumerable<NaoConformidadeModel> Index()
        {
            var naoConformidades = _naoConformidadeService.SelecionarTodos();
            return _mapper.Map<IEnumerable<NaoConformidadeModel>>(naoConformidades);
        }

    }
}
