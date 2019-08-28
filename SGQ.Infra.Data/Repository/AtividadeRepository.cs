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
            return (from atividade in context.Atividade
                   join user in context.Users on atividade.UsuarioCadastroId equals user.Id
                   select new Atividade
                   {
                       Nome = atividade.Nome,
                       Descricao = atividade.Descricao,
                       Ordem = atividade.Ordem,
                       UsuarioCadastro = user,
                       DataCadastro = atividade.DataCadastro

                   }).AsEnumerable();
        }
    }
}
