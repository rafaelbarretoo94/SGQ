using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class NormaTema
    {
        public int NormaId { get; set; }
        public Norma Norma { get; set; }
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
    }
}
