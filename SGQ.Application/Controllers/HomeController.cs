using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGQ.Application.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper) : base(mapper)
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}