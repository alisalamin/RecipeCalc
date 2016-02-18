using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    /// <summary>
    /// Generic Repository that performs basic CRUD for all types that implement IEntity.
    /// </summary>
    /// <typeparam name="TEntity">IEntity implementation. Ex. Product</typeparam>
    /// <typeparam name="TKey">Generic unique id type, must match id type of the IEntity type being used. Ex. For Product, the type is long.</typeparam>
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<TEntity> List()
        {
            return _unitOfWork.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Set<TEntity>()
                               .Where(predicate)
                               .AsEnumerable();
        }

        public TEntity GetById(TKey id)
        {
            return _unitOfWork.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _unitOfWork.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Set<TEntity>().Remove(entity);
        }

        public void CommitChanges(TEntity entity)
        {
            _unitOfWork.SaveChanges();
        }
    }
}
