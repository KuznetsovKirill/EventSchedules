using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Contract
{
    public interface IRepository
    {
        internal void SetContext(EventShedulesDbContext context);
    }
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        TEntity GetById(int id);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria = null);

        TEntity Add(TEntity entity);
    }
}
