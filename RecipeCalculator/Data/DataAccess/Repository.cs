using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        public IEnumerable<TEntity> List()
        {
            IEnumerable<TEntity> entityList;
            using (var unitOfWork = new UnitOfWork())
            {
                entityList = unitOfWork.Set<TEntity>().AsEnumerable();
            }

            return entityList;

        }

        public IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entityList;
            using (var unitOfWork = new UnitOfWork())
            {
                entityList = unitOfWork.Set<TEntity>()
                               .Where(predicate)
                               .AsEnumerable();
            }

            return entityList;
        }

        public TEntity GetById(int id)
        {
            TEntity entity;
            using (var unitOfWork = new UnitOfWork())
            {
                entity = unitOfWork.Set<TEntity>().Find(id);
            }

            return entity;
        }

        public void Insert(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Set<TEntity>().Add(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Set<TEntity>().Remove(entity);
            }
        }

        public void CommitChanges(TEntity entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SaveChanges();
            }
        }

    }
}
