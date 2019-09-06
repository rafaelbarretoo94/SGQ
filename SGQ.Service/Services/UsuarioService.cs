using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Service.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
        }

        public override IEnumerable<Usuario> SelecionarTodos()
        {
            var listUsuarios = base.SelecionarTodos();
            return from usuario in listUsuarios
                select new Usuario
                {
                    Id = usuario.Id,
                    Codigo = usuario.Codigo,
                    Nome = usuario.Nome,
                    UserName = usuario.UserName,
                    Email = usuario.Email
                };
        }
    }
}
