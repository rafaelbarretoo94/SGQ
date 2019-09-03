using Microsoft.EntityFrameworkCore;
using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class AtividadeRepository : Repository<Atividade>, IAtividadeRepository
    {
       

        public AtividadeRepository(SgqContext context) : base(context)
        {
        }

        public override IEnumerable<Atividade> SelecionarTodos()
        {
            var listAtividades = context.Atividade;

            foreach(var atividade in listAtividades)
            {
                atividade.UsuarioCadastro = new Usuario();
                atividade.UsuarioModificacao = new Usuario();

                atividade.UsuarioCadastro.Email = context.Users
                    .Where(x => x.Id == atividade.UsuarioCadastroId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                atividade.UsuarioModificacao.Email = context.Users
                    .Where(x => x.Id == atividade.UsuarioModificacaoId)
                    .Select(x => x.Email)
                    .FirstOrDefault();
            }

            return listAtividades;
        }
    }
}
