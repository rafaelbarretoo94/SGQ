using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class NaoConformidadeService : BaseService<NaoConformidade>, INaoConformidadeService
    {
        public NaoConformidadeService(INaoConformidadeRepository _naoConformidadeRepository) : base(_naoConformidadeRepository)
        {

        }
    }
}
