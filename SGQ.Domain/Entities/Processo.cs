﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGQ.Domain.Entities
{
    public class Processo : BaseEntity
    {
        public string Nome { get; set; }
        public int PeriodicidadeId { get; set; }
        public int StatusId { get; set; }
        public List<Atividade> Atividades { get; set; }

        [NotMapped]
        public EnumBase Status { get; set; }
        public EnumBase Periodicidade { get; set; }
    }
}
