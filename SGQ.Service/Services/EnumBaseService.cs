using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class EnumBaseService : BaseService<EnumBase>, IEnumBaseService
    {
        private IEnumBaseRepository _enumBaseRepository;
        public EnumBaseService(IEnumBaseRepository enumBaseRepository) : base(enumBaseRepository)
        {
            _enumBaseRepository = enumBaseRepository;
        }

        public IEnumerable<EnumBase> ObterEnumBasePorTipo(string tipoEnum)
        {
            return _enumBaseRepository.ObterEnumBasePorTipo(tipoEnum);
        }
    }
}
