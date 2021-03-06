﻿using SGQ.Domain.Entities;
using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository.Interfaces
{
    public interface INaoConformidadeRepository : IRepository<NaoConformidade>
    {
        void AtualizarCodigo(NaoConformidade naoConformidade);
    }
}
