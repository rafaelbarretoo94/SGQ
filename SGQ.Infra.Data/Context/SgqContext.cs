using Microsoft.EntityFrameworkCore;
using System.Configuration;
using SGQ.Domain.Entities;
using Microsoft.IdentityModel.Protocols;

namespace SGQ.Infra.Data.Context
{
    public class SgqContext : DbContext
    {
        private readonly string connectionString;

        public SgqContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//              #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Acao> Acao { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<NaoConformidade> NaoConformidade { get; set; }
        public DbSet<Norma> Norma { get; set; }
        public DbSet<Processo> Processo { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConfigurationManager<T>.ConnectionStrings["SQGDataBase"].ConnectionString,  );
        //}
    }
}
