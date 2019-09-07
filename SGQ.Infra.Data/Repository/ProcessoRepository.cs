using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class ProcessoRepository : Repository<Processo>, IProcessoRepository
    {
        private readonly string _codigo = "PR";

        public ProcessoRepository(SgqContext context) : base(context)
        {
        }

        public void AtualizarCodigo(Processo processo)
        {
            processo.Codigo = _codigo + processo.Id;
            context.Processo.Update(processo);
            context.SaveChanges();
        }

        public override Processo Adicionar(Processo entity)
        {
            Processo processo = base.Adicionar(entity);
            AtualizarCodigo(processo);
            return processo;
        }

        public override IEnumerable<Processo> SelecionarTodos()
        {
            var listProcesso = context.Processo;

            IEnumerable<EnumBase> listPeriodicidadeProcesso = context.EnumBase.Where(x => x.TipoEnum == "PeriodicidadeVerificacaoProcesso");
            IEnumerable<EnumBase> listStatusProcesso = context.EnumBase.Where(x => x.TipoEnum == "StatusProcesso");

            foreach (var processo in context.Processo)
            {
                processo.UsuarioCadastro = new Usuario();
                processo.UsuarioModificacao = new Usuario();

                processo.Status = listStatusProcesso
                    .Where(x => x.Id == processo.StatusId)
                    .FirstOrDefault();

                processo.Periodicidade = listPeriodicidadeProcesso
                    .Where(x => x.Id == processo.PeriodicidadeId)
                    .FirstOrDefault();

                processo.UsuarioCadastro.Email = context.Users
                    .Where(x => x.Id == processo.UsuarioCadastroId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                processo.UsuarioModificacao.Email = context.Users
                    .Where(x => x.Id == processo.UsuarioModificacaoId)
                    .Select(x => x.Email)
                    .FirstOrDefault();
            }

            return listProcesso;
        }
    }
}
