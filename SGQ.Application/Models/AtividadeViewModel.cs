using SGQ.Domain.Entities;
using System;

namespace SGQ.Application.Models
{
    public class AtividadeViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string NomeUsuarioCadastro { get; set; }
        public string NomeUsuarioModificacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
