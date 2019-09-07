using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGQ.Domain.Entities
{
    public class NaoConformidade : BaseEntity
    {
        public int TipoNaoConformidadeId { get; set; }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public string AnaliseCausaRaiz { get; set; }
        public string Descricao { get; set; }
        public string Evidencia { get; set; }
        public ICollection<Norma> Normas { get; set; }
        public string UsuarioResponsavelId { get; set; }
        public DateTime DataAvaliacao { get; set; }

        [NotMapped]
        public EnumBase TipoNaoConformidade { get; set; }
        public Usuario UsuarioResponsavel { get; set; }
    }
}
