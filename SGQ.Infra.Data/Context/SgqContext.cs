using Microsoft.EntityFrameworkCore;
using System.Configuration;
using SGQ.Domain.Entities;
using Microsoft.IdentityModel.Protocols;

namespace SGQ.Infra.Data.Context
{
    public class SgqContext : DbContext
    {

        public SgqContext(DbContextOptions<SgqContext> options) : base(options)
        {
        }

        public DbSet<Acao> Acao { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<NaoConformidade> NaoConformidade { get; set; }
        public DbSet<Norma> Norma { get; set; }
        public DbSet<Processo> Processo { get; set; }
    }
}
