using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using BusinessLogic.Models;

namespace BusinessLogic.Test
{
    [TestClass]
    public class When_Calculating_Sales_Tax
    {
        public TestContext TestContext { get; set; }

        //Note: Normally this would be retrieved from a copy of the database that is created for testing, then destroyed when testing is complete.
        private const decimal TaxRate = 8.6m;

        [TestMethod]
        public void Retrieve_AdjustmentRate_Settings()
        {
            var calc = new RecipeCalculator();
            var salesTax = calc.AppSettings.SalesTax;
            TestContext.WriteLine("*** Testing writing to the screen to demo recipe totals later on. ***");

            Assert.AreEqual(TaxRate, salesTax);
        }

        //When Calculating Sales Tax, it should be by the amount specified in the Adjustments Table.
        [TestMethod]
        public void Verify_Tax_Rate_Is_Correct()
        {
            var calc = new RecipeCalculator();
            var ingredient = new IngredientBO();
            decimal beforeTax = calc.BeforeTaxPrice(ingredient);
            decimal afterTax = calc.ApplySalesTax(ingredient);

            //Calculate if return decimal is 8.6% of the Ingredient price.
            var percentageDifference = Math.Round((Math.Round((afterTax - beforeTax), 3) / beforeTax), 3) * 100;

            Assert.AreEqual(percentageDifference, TaxRate, "woohoo!");
        }


        //When Calculating Sales Tax it should be rounded up to the nearest hundredth.

       

    }
}
