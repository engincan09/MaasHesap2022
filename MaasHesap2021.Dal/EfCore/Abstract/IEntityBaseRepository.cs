using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MaasHesap2022.Dal.EfCore.Abstract
{
    public interface IEntityBaseRepository<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
    }
}
