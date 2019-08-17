using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Tema : BaseEntity
    {
        public ICollection<NormaTema> NormaTemas { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
