using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClimbingRoutes
{
    public class ClimbingRoutesRepository<TEntity> : IClimbingRoutesRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public ClimbingRoutesRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All() => _dbSet.AsNoTracking().ToList();

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) =>
            _dbSet.AsNoTracking().Where(predicate).ToList();

        public TEntity FindByKey(int id) =>
            _dbSet.AsNoTracking().SingleOrDefault(Utilities.BuildLambdaForFindByKey<TEntity>(id));


        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = FindByKey(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}