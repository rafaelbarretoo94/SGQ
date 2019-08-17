using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Tema : BaseEntity
    {
        public List<Norma> Normas { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
