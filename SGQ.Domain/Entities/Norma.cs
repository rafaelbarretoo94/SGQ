using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Norma : BaseEntity
    {

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public string Ambito { get; set; }

        public DateTime Data { get; set; }

        public string Escopop { get; set; }

        public string Temas { get; set; }

        public string Texto { get; set; }
        
    }
}
