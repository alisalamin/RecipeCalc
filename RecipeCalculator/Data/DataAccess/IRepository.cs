using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<TEntity, in TKey> where TEntity : IEntity<int>
    {
        IEnumerable<TEntity> List { get; }

        TEntity GetById(TKey id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
