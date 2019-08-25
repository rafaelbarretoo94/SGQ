using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class NormaTemaRepository : Repository<NormaTema>, INormaTemaRepository
    {
        public NormaTemaRepository(SgqContext context) : base(context)
        {
        }
    }
}
