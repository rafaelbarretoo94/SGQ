using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SGQ.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public SgqContext context;
        public DbSet<TEntity> DbSet;

        public Repository(SgqContext context)
        {
            this.context = context;
            DbSet = this.context.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> SelecionarTodos()
        {
            return DbSet.ToList();
        }

        public TEntity Atualizar(TEntity entity)
        {
            var entry = context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
