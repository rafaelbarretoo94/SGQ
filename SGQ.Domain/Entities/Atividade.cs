using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    class Atividade : BaseEntity
    {
        
        public string Nome { get; set; }

        public string Descricao { get; set; }        

        public Ordem Ordem { get; set; }

    }
}
