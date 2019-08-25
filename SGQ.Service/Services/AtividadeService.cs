using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class AtividadeService : BaseService<Atividade>, IAtividadeService
    {
        public AtividadeService(IAtividadeRepository _atividadeRepository) : base(_atividadeRepository)
        {
        }

        public override Atividade Adicionar(Atividade entity)
        {
            //if(ModelState.)
            return base.Adicionar(entity);
        }
    }
}
