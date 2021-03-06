﻿using SGQ.Domain.Entities;
using SGQ.Infra.Data.Repository.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Services
{
    public class NaoConformidadeService : BaseService<NaoConformidade>, INaoConformidadeService
    {
        public NaoConformidadeService(INaoConformidadeRepository naoConformidadeRepository) : base(naoConformidadeRepository)
        {
        }

        public override NaoConformidade Adicionar(NaoConformidade entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.DataModificacao = DateTime.Now;
            return base.Adicionar(entity);
        }
    }
}
