using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class AcaoRepository : Repository<Acao>, IAcaoRepository
    {       
        public AcaoRepository(SgqContext context) : base(context)
        {
        }
    }
}
