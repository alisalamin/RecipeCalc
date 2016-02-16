using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    public class RecipeCalculator
    {
        public decimal ApplySalesTax(IRecipe recipe)
        {

           // var x = new IngredientRepo();
            

            throw new NotImplementedException();
        }


        public RateAdjustmentBO GetRateAdjustments()
        {
            var appRateRepo = new Repository<RateAdjustment>();
            var appRate = appRateRepo.GetById(1);

            //var z = appRateRepo.List().Where(x => x.)


            return new RateAdjustmentBO()
            {
                Id = appRate.Id,
                SalesTax = appRate.SalesTax,
                WellnessDiscountRate = appRate.WellnessDiscountRate
            };
        }


        //Apply Wellness Discount


        //Calculate Total Cost

    }
}
