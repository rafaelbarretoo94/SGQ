using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class NaoConformidadeRepository : Repository<NaoConformidade>, INaoConformidadeRepository
    {
        private readonly string _codigo = "NC";

        public NaoConformidadeRepository(SgqContext context) : base(context)
        {
        }

        public void AtualizarCodigo(NaoConformidade naoConformidade)
        {
            naoConformidade.Codigo = _codigo + naoConformidade.Id;
            context.NaoConformidade.Update(naoConformidade);
            context.SaveChanges();
        }

        public override NaoConformidade Adicionar(NaoConformidade entity)
        {
            NaoConformidade naoConformidade = base.Adicionar(entity);
            AtualizarCodigo(naoConformidade);
            return naoConformidade;
        }

        public override IEnumerable<NaoConformidade> SelecionarTodos()
        {
            var listNaoConformidade = context.NaoConformidade;
            IEnumerable<EnumBase> listTipoNaoConformidade = context.EnumBase.Where(x => x.TipoEnum == "TipoNaoConformidade");

            foreach (var naoConformidade in listNaoConformidade)
            {
                naoConformidade.UsuarioCadastro = new Usuario();
                naoConformidade.UsuarioModificacao = new Usuario();
                naoConformidade.UsuarioResponsavel = new Usuario();

                naoConformidade.TipoNaoConformidade = listTipoNaoConformidade
                    .Where(x => x.Id == naoConformidade.TipoNaoConformidadeId)
                    .FirstOrDefault();

                naoConformidade.Processo = context.Processo
                    .Where(x => x.Id == naoConformidade.ProcessoId)
                    .FirstOrDefault();

                naoConformidade.UsuarioCadastro.Email = context.Users
                    .Where(x => x.Id == naoConformidade.UsuarioCadastroId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                naoConformidade.UsuarioModificacao.Email = context.Users
                    .Where(x => x.Id == naoConformidade.UsuarioModificacaoId)
                    .Select(x => x.Email)
                    .FirstOrDefault();

                naoConformidade.UsuarioResponsavel.Email = context.Users
                    .Where(x => x.Id == naoConformidade.UsuarioResponsavelId)
                    .Select(x => x.Email)
                    .FirstOrDefault();
            }

            return listNaoConformidade;
        }
    }
}
