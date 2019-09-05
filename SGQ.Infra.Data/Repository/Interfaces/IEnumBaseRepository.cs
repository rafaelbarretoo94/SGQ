using SGQ.Domain.Entities;
using SGQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository.Interfaces
{
    public interface IEnumBaseRepository : IRepository<EnumBase>
    {
        IEnumerable<EnumBase> ObterEnumBasePorTipo(string tipoEnum);
    }
}
