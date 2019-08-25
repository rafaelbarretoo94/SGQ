﻿using SGQ.Domain.Entities;
using SGQ.Infra.Data.Context;
using SGQ.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Infra.Data.Repository
{
    public class NormaEscopoRepository : Repository<NormaEscopo>, INormaEscopoRepository
    {
        public NormaEscopoRepository(SgqContext context) : base(context)
        {
        }
    }
}
