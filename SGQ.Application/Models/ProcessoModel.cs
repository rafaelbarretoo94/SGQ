using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class ProcessoModel
    {
        public string Nome { get; set; }
        public int Periodo { get; set; } // Deve ser convertido em enum
        public int Status { get; set; } // Deve ser convertido em enum 
        public List<Atividade> Atividades { get; set; }
    }
}
