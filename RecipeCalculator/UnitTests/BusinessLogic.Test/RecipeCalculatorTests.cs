using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogic.Test
{
    [TestClass]
    public class When_Calculating_Sales_Tax
    {
        //Note: Normally this would be retrieved from a copy of the database that is created for testing, then destroyed when testing is complete.
        private const decimal TaxRate = 0.086m;

 

        //When Calculating Sales Tax, it should be by the amount specified in the Adjustments Table.
        [TestMethod]
        public void Verify_Tax_Percentage_Is_Correct()
        {
            var calc = new RecipeCalculator();
            var salesTax = calc.GetRateAdjustments().SalesTax;
            Assert.AreEqual(TaxRate, salesTax);
        }


        //When Calculating Sales Tax it should be rounded up to the nearest hundredth.

    }
}
