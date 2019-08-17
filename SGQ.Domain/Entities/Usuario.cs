using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SGQ.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
