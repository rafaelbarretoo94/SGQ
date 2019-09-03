using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class ProcessoService : BaseService<Processo>, IProcessoService
    {
        private static readonly SgqContext sgqContext;
        private static readonly IProcessoRepository _processoRepository;
        public ProcessoService() : base(_processoRepository, sgqContext)
        {
        }
    }
}
