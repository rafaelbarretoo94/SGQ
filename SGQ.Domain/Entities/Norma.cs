using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Norma : BaseEntity
    { 
        public string Nome { get; set; }
        public int AmbitoId { get; set; }
        public Ambito Ambito { get; set; }
        public DateTime Data { get; set; }
        public ICollection<NormaEscopo> NormaEscopos { get; set; }
        public ICollection<NormaTema> NormaTemas { get; set; }
        public string Texto { get; set; }
    }
}
