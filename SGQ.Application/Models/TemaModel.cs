using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class TemaModel
    {
        public ICollection<NormaTema> NormaTemas { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
