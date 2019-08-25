using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class NormaTemaModel
    {
        public int NormaId { get; set; }
        public Norma Norma { get; set; }
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
    }
}
