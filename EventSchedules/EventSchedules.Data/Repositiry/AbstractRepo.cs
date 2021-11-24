using EventSchedules.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Repositiry
{
    public abstract class AbstractRepo<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected EventShedulesDbContext _eventShedulesContext;

        public TEntity GetById(int id)
        {
            return _eventShedulesContext.Set<TEntity>().Find(id);
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }

            try
            {
                _eventShedulesContext.Remove(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be delete: {ex.Message}", ex);
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria = null)
        {
            IQueryable<TEntity> query = _eventShedulesContext.Set<TEntity>();
            if (criteria != null)
            {
                query = query.Where(criteria);
            }
            return query.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }

            try
            {
                _eventShedulesContext.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}", ex);
            }
        }

        void IRepository.SetContext(EventShedulesDbContext context)
        {
            _eventShedulesContext = context;
        }
    }
}
