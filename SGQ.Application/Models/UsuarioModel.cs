using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class UsuarioModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
