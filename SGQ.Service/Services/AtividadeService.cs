using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class AtividadeService : BaseService<Atividade>, IAtividadeService
    {
        private static readonly SgqContext _sgqContext;
        private static readonly IAtividadeRepository _atividadeRepository;
        public AtividadeService() : base(_atividadeRepository,_sgqContext)
        {
        }

        public override Atividade Adicionar(Atividade entity)
        {
            //if(ModelState.)
            return base.Adicionar(entity);
        }
    }
}
