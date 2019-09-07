using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class EnumBaseRepository : Repository<EnumBase>, IEnumBaseRepository
    {
        public EnumBaseRepository(SgqContext context) : base(context)
        {
        }

        public IEnumerable<EnumBase> ObterEnumBasePorTipo(string tipoEnum)
        {
            return context.EnumBase
                .Where(x => x.TipoEnum == tipoEnum);
        }
    }
}
