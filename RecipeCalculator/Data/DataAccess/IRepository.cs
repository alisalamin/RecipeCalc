using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<TEntity> where TEntity : IEntity<int>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void CommitChanges(TEntity entity);
    }
}
