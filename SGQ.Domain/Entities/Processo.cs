using System.Collections.Generic;

namespace SGQ.Domain.Entities
{
    public class Processo : BaseEntity
    {
        public string Nome { get; set; }
        public int Periodo { get; set; } // Deve ser convertido em enum
        public int Status { get; set; } // Deve ser convertido em enum 
        public List<Atividade> Atividades { get; set; }
    }
}
