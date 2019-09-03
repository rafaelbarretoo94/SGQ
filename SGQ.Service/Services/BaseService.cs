using SGQ.Domain.Interfaces;
using SGQ.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGQ.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class 
    {
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            return _repository.Adicionar(entity);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            return _repository.Atualizar(entity);
        }

        public virtual void Remover(int id)
        {
            _repository.Remover(id);
        }

        public virtual IEnumerable<TEntity> SelecionarTodos()
        {
            return _repository.SelecionarTodos().AsEnumerable();
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
