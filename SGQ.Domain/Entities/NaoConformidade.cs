using SGQ.Domain.Entities;
using System;

namespace SGQ.Domain.Entities
{
    public class NaoConformidade : BaseEntity
    {
      

        public int TipoConformidade { get; set; }

        public string CodigoProcessoAutomotivo { get; set; }

        public string AnaliseCausaRaiz { get; set; }

        public string Descricao { get; set; }

        public string Evidencia { get; set; }

        public Norma Norma { get; set; }

        public string Responsavel { get; set; }

        public DateTime DataAvaliacao { get; set; }

    }
}
