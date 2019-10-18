using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClimbingRoutes
{
    public interface IClimbingRoutesRepository<TEntity>
    {
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        public TEntity FindByKey(int id);
        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}