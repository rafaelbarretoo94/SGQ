using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class ProcessoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        [Display(Name ="Período")]
        public int PeriodicidadeId { get; set; }
        public EnumBase Periodicidade { get; set; }
        public int StatusId { get; set; }
        public EnumBase Status { get; set; }
        public List<Atividade> Atividades { get; set; }
    }
}
