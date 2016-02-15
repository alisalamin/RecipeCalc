using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    class ProductsRepo : IRepository<IProduct, int>
    {
        public IEnumerable<IProduct> List
        {
            get { throw new NotImplementedException(); }
        }

        public IProduct GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(IProduct entity)
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
    }
}
