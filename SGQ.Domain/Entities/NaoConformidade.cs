using System;
using System.Collections.Generic;

namespace SGQ.Domain.Entities
{
    public class NaoConformidade : BaseEntity
    {
        public int TipoConformidade { get; set; }
        public string ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public string AnaliseCausaRaiz { get; set; }
        public string Descricao { get; set; }
        public string Evidencia { get; set; }
        public List<Norma> Normas { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
