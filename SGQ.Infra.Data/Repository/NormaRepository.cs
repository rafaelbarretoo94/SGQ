using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class NormaRepository : Repository<Norma>, INormaRepository
    {
        public NormaRepository(SgqContext context) : base(context)
        {
        }
    }
}
