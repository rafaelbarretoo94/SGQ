using SGQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Adicionar(T entity);
        T ObterPorId(int id);
        T Atualizar(T entity);
        void Remover(int id);
        IEnumerable<T> SelecionarTodos();
    }
}
