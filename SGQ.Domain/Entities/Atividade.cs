using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class Atividade : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }        
        public int Ordem { get; set; }
        public int ProcessoId { get; set; }
    }
}
