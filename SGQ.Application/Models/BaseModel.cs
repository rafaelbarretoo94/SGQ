using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Application.Models
{
    public class BaseModel
    {
        public virtual int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string UsuarioCadastroId { get; set; }
        public string UsuarioModificacaoId { get; set; }

        [NotMapped]
        public bool IsValid { get; set; }
        public Usuario UsuarioCadastro;
        public Usuario UsuarioModificacao;
    }
}
