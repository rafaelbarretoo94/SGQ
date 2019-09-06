using System.Collections.Generic;

namespace SGQ.Domain.Entities
{
    public class Processo : BaseEntity
    {
        public string Nome { get; set; }
        public int PeriodicidadeId { get; set; }
        public EnumBase Periodicidade { get; set; }
        public int StatusId { get; set; }
        public EnumBase Status { get; set; }
        public List<Atividade> Atividades { get; set; }
    }
}
