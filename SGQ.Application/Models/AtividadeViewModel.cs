using SGQ.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGQ.Application.Models
{
    public class AtividadeViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        [Display(Name = "Nome Usuário Cadastro")]
        public string NomeUsuarioCadastro { get; set; }

        [Display(Name = "Nome Usuário Modificação")]
        public string NomeUsuarioModificacao { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data Modificação")]
        public DateTime DataModificacao { get; set; }
    }
}
