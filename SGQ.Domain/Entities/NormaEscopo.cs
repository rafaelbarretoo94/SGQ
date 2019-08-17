using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class NormaEscopo
    {
        public int NormaId { get; set; }
        public Norma Norma { get; set; }
        public int EscopoId { get; set; }
        public Escopo Escopo { get; set; }
    }
}
