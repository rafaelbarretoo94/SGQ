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
        private readonly string _codigo = "AT";

        public AtividadeRepository(SgqContext context) : base(context)
        {
        }

        public void AtualizarCodigo(Atividade atividade)
        {
            atividade.Codigo = _codigo + atividade.Id;
            context.Atividade.Update(atividade);
            context.SaveChanges();
        }

        public override Atividade Adicionar(Atividade entity)
        {
            Atividade atividade = base.Adicionar(entity);
            AtualizarCodigo(atividade);
            return atividade;
        }

        public override IEnumerable<Atividade> SelecionarTodos()
        {
            var listAtividades = context.Atividade;

            foreach(var atividade in listAtividades)
            {
                atividade.UsuarioCadastro = new Usuario();
                atividade.UsuarioModificacao = new Usuario();
                atividade.Processo = new Processo();

                atividade.UsuarioCadastro.Email = context.Users
                    .Where(x => x.Id == atividade.UsuarioCadastroId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                atividade.UsuarioModificacao.Email = context.Users
                    .Where(x => x.Id == atividade.UsuarioModificacaoId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                atividade.Processo.Nome = context.Processo
                    .Where(x => x.Id == atividade.ProcessoId)
                    .Select(x => x.Nome)
                    .FirstOrDefault();
            }

            return listAtividades;
        }
    }
}
