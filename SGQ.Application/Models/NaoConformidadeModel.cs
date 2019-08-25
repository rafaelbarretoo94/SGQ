using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGQ.Application.Models;
using SGQ.Domain.Entities;

namespace SGQ.Application.Models
{
    public class NaoConformidadeModel
    {
        public int TipoConformidade { get; set; }
        public string ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public string AnaliseCausaRaiz { get; set; }
        public string Descricao { get; set; }
        public string Evidencia { get; set; }
        public ICollection<Norma> Normas { get; set; }
        public int UsuarioResponsavelId { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
