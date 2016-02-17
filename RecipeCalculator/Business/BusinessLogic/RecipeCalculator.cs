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
    public class RecipeCalculator : BaseManager
    {

       

        public decimal TotalCost(IRecipe recipe)
        {

            // var x = new IngredientRepo();


            throw new NotImplementedException();
        }


        public AppSettingsBO GetRateAdjustments()
        {

            return AppSettings;
           
        }


        //Apply Wellness Discount


        //Calculate Total Cost



        public decimal ApplySalesTax(IngredientBO ingredient)
        {
            throw new NotImplementedException();
        }

        public decimal BeforeTaxPrice(IngredientBO ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
