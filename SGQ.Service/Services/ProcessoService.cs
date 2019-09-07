using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class ProcessoService : BaseService<Processo>, IProcessoService
    {
        public ProcessoService(IProcessoRepository processoRepository) : base(processoRepository)
        {
        }

        public override Processo Adicionar(Processo entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.DataModificacao = DateTime.Now;
            return base.Adicionar(entity);
        }
    }
}
