﻿using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class NaoConformidadeService : BaseService<NaoConformidade>, INaoConformidadeService
    {
        private static readonly SgqContext _sgqContext;
        private static readonly INaoConformidadeRepository _naoConformidadeRepository;
        public NaoConformidadeService() : base(_naoConformidadeRepository,_sgqContext)
        {

        }
    }
}
