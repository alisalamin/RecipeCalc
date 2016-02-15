using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogic.Test
{
    [TestClass]
    public class RecipeCalculatorBasicCalculationsUnitTests
    {
        //Note: Normally this would be retrieved from a copy of the database that is created for testing, then destroyed when testing is complete.
        private const decimal TaxRate = 0.086m;




        [TestMethod]
        public void Verify_Tax_Percentage_Is_Correct()
        {
            var calc = new RecipeCalculator();


            var result = calc.ApplySalesTax();


            Assert.IsTrue((result == TaxRate), "The correct TaxRate has been used.");


        }
    }
}
