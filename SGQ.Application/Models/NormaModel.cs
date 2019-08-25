using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class NormaModel
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
