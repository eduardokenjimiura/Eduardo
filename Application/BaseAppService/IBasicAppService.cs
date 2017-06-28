using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application
{
    public interface IAppService<TEntity>
        where TEntity : class
    {
        bool Create(TEntity orderDetail);
        bool Update(TEntity orderDetail);
        bool Remove(TEntity orderDetail);
        TEntity procurar(int id, bool @readonly = false);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}