using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class NormaEscopoModel
    {
        public int NormaId { get; set; }
        public Norma Norma { get; set; }
        public int EscopoId { get; set; }
        public Escopo Escopo { get; set; }
    }
}
