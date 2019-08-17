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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NormaEscopo>()
                .HasKey(na => new { na.NormaId, na.EscopoId });

            modelBuilder.Entity<NormaEscopo>()
                .HasOne(na => na.Norma)
                .WithMany(n => n.NormaEscopos)
                .HasForeignKey(na => na.NormaId);

            modelBuilder.Entity<NormaEscopo>()
                .HasOne(na => na.Escopo)
                .WithMany(e => e.NormaEscopos)
                .HasForeignKey(na => na.EscopoId);

            modelBuilder.Entity<NormaTema>()
                .HasKey(na => new { na.NormaId, na.TemaId });

            modelBuilder.Entity<NormaTema>()
                .HasOne(na => na.Norma)
                .WithMany(n => n.NormaTemas)
                .HasForeignKey(na => na.NormaId);

            modelBuilder.Entity<NormaTema>()
                .HasOne(na => na.Tema)
                .WithMany(e => e.NormaTemas)
                .HasForeignKey(na => na.TemaId);
        }
    }
}
