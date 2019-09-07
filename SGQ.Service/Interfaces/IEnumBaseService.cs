using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Interfaces
{
    public interface IEnumBaseService : IBaseService<EnumBase>
    {
        IEnumerable<EnumBase> ObterEnumBasePorTipo(string tipoEnum);
    }
}
