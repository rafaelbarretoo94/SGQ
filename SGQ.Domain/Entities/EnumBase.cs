using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Entities
{
    public class EnumBase : BaseEntity
    {
        public string TipoEnum { get; set; }
        public string Valor { get; set; }
    }
}
