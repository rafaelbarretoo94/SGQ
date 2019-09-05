using SGQ.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGQ.Application.Models
{
    public class AtividadeViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
        public int Ordem { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        
    }
}
