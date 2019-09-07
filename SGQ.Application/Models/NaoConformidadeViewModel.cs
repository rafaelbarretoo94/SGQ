using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SGQ.Application.Models;
using SGQ.Domain.Entities;

namespace SGQ.Application.Models
{
    public class NaoConformidadeViewModel : BaseViewModel
    {
        public int TipoNaoConformidadeId { get; set; }
        [Display(Name = "Tipo")]
        public EnumBase TipoNaoConformidade { get; set; }
        public int ProcessoId { get; set; }
        [Display(Name = "Processo")]
        public Processo Processo { get; set; }
        [Display(Name = "Analise Causa Raiz")]
        public string AnaliseCausaRaiz { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Evidência")]
        public string Evidencia { get; set; }
        public ICollection<Norma> Normas { get; set; }
        public string UsuarioResponsavelId { get; set; }
        [Display(Name = "Usuário Responsavel - Verificação")]
        public Usuario UsuarioResponsavel { get; set; }
        [Display(Name = "Data Avaliação")]
        public DateTime DataAvaliacao { get; set; }     
    }
}
