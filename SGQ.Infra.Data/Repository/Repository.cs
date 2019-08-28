using SGQ.Domain.Interfaces;
using SGQ.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SGQ.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public SgqContext context;
        public DbSet<T> DbSet;

        public Repository(SgqContext context)
        {
            this.context = context;
            DbSet = this.context.Set<T>();
        }

        public virtual T Adicionar(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<T> SelecionarTodos()
        {
            return DbSet.ToList();
        }

        public T Atualizar(T entity)
        {
            var entry = context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public T ObterPorId(int id)
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
