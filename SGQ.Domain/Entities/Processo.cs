using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    class Processo : BaseEntity
    { 
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public int Periodo { get; set; } // Deve ser convertido em enum

        public int Status { get; set; } // Deve ser convertido em enum 

        public List<Atividade> Atividades { get; set; }

    }
}
