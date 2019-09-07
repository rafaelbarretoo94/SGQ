using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Service.Interfaces
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        TEntity Atualizar(TEntity entity);
        void Remover(int id);
        IEnumerable<TEntity> SelecionarTodos();
    }
}
