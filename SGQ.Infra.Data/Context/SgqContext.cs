using Microsoft.EntityFrameworkCore;
using SGQ.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SGQ.Infra.Data.Context
{
    public class SgqContext : IdentityDbContext<Usuario>
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
        public DbSet<EnumBase> EnumBase { get; set; }

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

            modelBuilder.Entity<EnumBase>().HasData(new EnumBase
            {
                Id = 1,
                TipoEnum = "PeriodicidadeVerificacaoProcesso",
                Valor = "Diaria"
            },
            new EnumBase
            {
                Id = 2,
                TipoEnum = "PeriodicidadeVerificacaoProcesso",
                Valor = "Semanal"
            },
            new EnumBase
            {
                Id = 3,
                TipoEnum = "PeriodicidadeVerificacaoProcesso",
                Valor = "Mensal"
            },
            new EnumBase
            {
                Id = 4,
                TipoEnum = "StatusProcesso",
                Valor = "Pré Cadastrado"
            },
            new EnumBase
            {
                Id = 5,
                TipoEnum = "StatusProcesso",
                Valor = "Ativo"
            },
            new EnumBase
            {
                Id = 6,
                TipoEnum = "StatusProcesso",
                Valor = "Cancelado"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
