using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Escopo : BaseEntity
    {
        public ICollection<NormaEscopo> NormaEscopos { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
