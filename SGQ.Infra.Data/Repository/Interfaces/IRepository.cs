using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        TEntity Atualizar(TEntity entity);
        void Remover(int id);
        IEnumerable<TEntity> SelecionarTodos();
    }
}
