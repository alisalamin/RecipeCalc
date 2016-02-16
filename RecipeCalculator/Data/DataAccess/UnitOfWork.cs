using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Models;


namespace DataAccess
{
    internal class UnitOfWork : DbContext
    {
        public UnitOfWork()
            : base("name=RecipeMakerDB")
        { }

        public IDbSet<Ingredient> Ingredients { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<RateAdjustment> RateAdjustments { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
    }
}
