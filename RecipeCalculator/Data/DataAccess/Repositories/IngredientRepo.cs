using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class IngredientRepo : IRepository<Ingredient>
    {
        public IEnumerable<Ingredient> List
        {
            get { throw new NotImplementedException(); }
        }

        public Ingredient GetById(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {

            }

            return new Ingredient();
        }

        public void Insert(Ingredient entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Ingredients.Add(entity);//is this cast excessive?
            }

            throw new NotImplementedException();
        }

        public void Update(Ingredient entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {

            }
        }

        public void Delete(Ingredient entity)
        {
            using (var unitOfWork = new UnitOfWork())
            {

            } throw new NotImplementedException();
        }


        public void CommitChanges(Ingredient entity)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Ingredient> IRepository<Ingredient>.List()
        {
            throw new NotImplementedException();
        }




        IEnumerable<Ingredient> IRepository<Ingredient>.List(System.Linq.Expressions.Expression<Func<Ingredient, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
