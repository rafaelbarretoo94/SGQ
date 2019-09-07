using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SGQ.Domain.Entities;

namespace SGQ.Application.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;

        public BaseController(IMapper mapper, [FromServices] IConfiguration config)
        {
            _mapper = mapper;
            _config = config;
        }

        protected async Task<string> ClientGetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var apiUser = _config.GetValue<string>("ApiUser");
                var apiPassword = _config.GetValue<string>("ApiPassword");
                var authenticationBytes = Encoding.ASCII.GetBytes(apiUser + ":" + apiPassword);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                       Convert.ToBase64String(authenticationBytes));
                HttpResponseMessage responseMessage = (await client.GetAsync(url));
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        protected async Task<string> ClientPostAsync(string url, string jsonContent)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var apiUser = _config.GetValue<string>("ApiUser");
                var apiPassword = _config.GetValue<string>("ApiPassword");
                var authenticationBytes = Encoding.ASCII.GetBytes(apiUser + ":" + apiPassword);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                       Convert.ToBase64String(authenticationBytes));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = (await client.PostAsync(url, content));
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }
    }
}