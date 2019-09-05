using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class BaseViewModel
    {
        public virtual int Id { get; set; }
        public string Codigo { get; set; }

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
