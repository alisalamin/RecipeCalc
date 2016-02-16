using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class ProductsRepo : IRepository<IProduct>
    {
        public IEnumerable<IProduct> List
        {
            get { throw new NotImplementedException(); }
        }

        public IProduct GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IProduct entity)
        {
            throw new NotImplementedException();
        }


        public void CommitChanges(IProduct entity)
        {
            throw new NotImplementedException();
        }


        IEnumerable<IProduct> IRepository<IProduct>.List()
        {
            throw new NotImplementedException();
        }


        IEnumerable<IProduct> IRepository<IProduct>.List(System.Linq.Expressions.Expression<Func<IProduct, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
