using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
   public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataModificacao { get; set; }
        public int UsuarioCadastroId { get; set; }
        public int UsuarioModificacaoId { get; set; }
    }
}
