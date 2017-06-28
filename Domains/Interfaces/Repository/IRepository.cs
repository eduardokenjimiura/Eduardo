using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domains.Repository
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Alterar(TEntity entity);
        void Deletar(TEntity entity);
        TEntity buscar(int id);
        IEnumerable<TEntity> buscarTodos(bool @readonly = false);
        IEnumerable<TEntity> buscarEspecifico(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}