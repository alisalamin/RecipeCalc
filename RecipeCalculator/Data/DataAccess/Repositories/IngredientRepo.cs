using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    class IngredientRepo : IRepository<IIngredient, int>
    {
        public IEnumerable<IIngredient> List
        {
            get { throw new NotImplementedException(); }
        }

        public IIngredient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(IIngredient entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IIngredient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IIngredient entity)
        {
            throw new NotImplementedException();
        }
    }
}
