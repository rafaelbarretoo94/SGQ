using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SGQ.Application.Models;
using SGQ.Domain.Entities;

namespace SGQ.Application.Models
{
    public class NaoConformidadeModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Display(Name ="Tipo Conformidade ")]
        public int TipoConformidade { get; set; }

        [Display(Name = "Processo Id")]
        public string ProcessoId { get; set; }
        public Processo Processo { get; set; }
        [Display(Name = "Analise Causa Raiz")]
        public string AnaliseCausaRaiz { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Evidência")]
        public string Evidencia { get; set; }
        public ICollection<Norma> Normas { get; set; }

        [Display(Name = "Usuário Responsave lId")]
        public int UsuarioResponsavelId { get; set; }

        [Display(Name = "  Data Avaliação ")]
        public DateTime DataAvaliacao { get; set; }

        [Display(Name = " Data Cadastro ")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data Modificacao")]
        public DateTime DataModificacao { get; set; }
        [Display(Name = "Usuário Cadastro Id ")]
        public int UsuarioCadastroId { get; set; }
        [Display(Name = "Usuário Modificação Id ")]
        public int UsuarioModificacaoId { get; set; }        
    }
}
