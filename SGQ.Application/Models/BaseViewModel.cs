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
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Display(Name = "Cadastrado por")]
        public string NomeUsuarioCadastro { get; set; }
        [Display(Name = "Atualizado por")]
        public string NomeUsuarioModificacao { get; set; }
        [Display(Name = "Cadastrado em")]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Última Atualização")]
        public DateTime DataModificacao { get; set; }
    }
}
