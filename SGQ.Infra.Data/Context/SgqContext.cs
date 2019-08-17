using Microsoft.EntityFrameworkCore;
using SGQ.Domain.Entities;

namespace SGQ.Infra.Data.Context
{
    public class SgqContext : DbContext
    {       
        public DbSet<Acao> Acao { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<NaoConformidade> NaoConformidade { get; set; }
        public DbSet<Norma> Norma { get; set; }
        public DbSet<Processo> Processo { get; set; }        
    }
}
