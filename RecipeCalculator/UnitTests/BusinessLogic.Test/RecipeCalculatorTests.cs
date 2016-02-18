using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BusinessLogic;
using BusinessLogic.Models;
using Common;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class RecipeCalculatorTests
    {
        public TestContext TestContext { get; set; }
        private const decimal TaxRate = 8.6m;
        private const decimal WelnessDiscountRate = 5.0m;

        [TestMethod]
        public void Retrieve_AdjustmentRate_Settings()
        {
            var calc = new RecipeCalculator();

            var salesTax = calc.AppSettings.SalesTax;

            Assert.IsNotNull(salesTax);
            Assert.AreEqual(TaxRate, salesTax);
        }

        [TestMethod]
        public void Verify_Price_Before_Tax()
        {
            var calc = new RecipeCalculator();
            var quantity = 2;
            var chicken = new IngredientBO()
            {
                Id = 1,
                ProductId = 4,
                Quantity = quantity,
                RecipeId = 1,
                UnitType = Enums.UnitTypes.None
            };
            var expected = (quantity * 2.19m);

            decimal beforeTax = calc.BeforeTaxPrice(chicken);

            Assert.IsNotNull(beforeTax);
            Assert.AreEqual(expected, beforeTax);
        }

        [TestMethod]
        public void Verify_Tax_Rate_Is_Correct()
        {
            var calc = new RecipeCalculator();
            var chicken = new IngredientBO()
            {
                Id = 1,
                ProductId = 4,
                Quantity = 17,
                RecipeId = 1,
                UnitType = Enums.UnitTypes.None
            };

            decimal beforeTax = calc.BeforeTaxPrice(chicken);
            decimal afterTax = calc.ApplySalesTax(beforeTax);
            var percentageDifference = Math.Round((Math.Round((afterTax - beforeTax), 2) / beforeTax), 3) * 100;

            Assert.IsNotNull(beforeTax);
            Assert.IsNotNull(afterTax);
            Assert.IsNotNull(percentageDifference);
            Assert.AreEqual(TaxRate, percentageDifference);
        }

        [TestMethod]
        public void Totals_Are_Using_Correct_Adjustment_Rates()
        {
            var calc = new RecipeCalculator();
            var receiptItems = calc.CreateRecipeReceipt(CreateRecipeTwo());
            var receiptTotals = calc.TotalCost(receiptItems);

            decimal beforeTax = receiptItems.FirstOrDefault(chicken => chicken.ProductId == 4).BeforeTaxTotal;
            decimal afterTax = calc.ApplySalesTax(beforeTax);
            var taxPercentageDifference = Math.Round((Math.Round((afterTax - beforeTax), 2) / beforeTax), 3) * 100;
            decimal beforeDiscount = receiptItems.FirstOrDefault(garlic => garlic.ProductId == 1).BeforeTaxTotal;
            decimal afterDiscount = calc.ApplyWellnessDiscount(beforeDiscount);
            var discountPercentageDifference = ((beforeDiscount - afterDiscount) / beforeDiscount) * 100;

            Assert.IsNotNull(receiptItems);
            Assert.IsNotNull(receiptTotals);
            Assert.AreNotEqual(0, receiptItems.Count);
            Assert.IsNotNull(discountPercentageDifference);
            Assert.AreEqual(WelnessDiscountRate, discountPercentageDifference);
            Assert.IsNotNull(taxPercentageDifference);
            Assert.AreEqual(TaxRate, taxPercentageDifference);

            //View receipt results in the Output pane.
            PrintReceiptToOutput(calc.CreateRecipeReceipt(CreateRecipeOne()), calc.TotalCost(calc.CreateRecipeReceipt(CreateRecipeOne())));
            PrintReceiptToOutput(calc.CreateRecipeReceipt(CreateRecipeTwo()), calc.TotalCost(calc.CreateRecipeReceipt(CreateRecipeTwo())));
            PrintReceiptToOutput(calc.CreateRecipeReceipt(CreateRecipeThree()), calc.TotalCost(calc.CreateRecipeReceipt(CreateRecipeThree())));
        }

        //Helpers
        private RecipeBO CreateRecipeOne()
        {
            var recipeOne = new RecipeBO()
            {
                Id = 1,
                RecipeName = "RecipeOne"
            };
            var ingredients = new List<IngredientBO>();
            ingredients.AddRange
            (
                new IngredientBO[]
                {
                    new IngredientBO()
                    {
                        Id = 1,
                        ProductId = 1, 
                        Quantity = 1,
                        RecipeId = 1,
                        UnitType = Enums.UnitTypes.Clove
                    },
                    new IngredientBO()
                    {
                        Id = 2,
                        ProductId = 2, 
                        Quantity = 1,
                        RecipeId = 1,
                        UnitType = Enums.UnitTypes.None
                    },
                    new IngredientBO()
                    {
                        Id = 3,
                        ProductId = 7, 
                        Quantity = 0.75m,
                        RecipeId = 1,
                        UnitType = Enums.UnitTypes.Cup
                    },
                    new IngredientBO()
                    {
                        Id = 4,
                        ProductId = 9, 
                        Quantity = 0.75m,
                        RecipeId = 1,
                        UnitType = Enums.UnitTypes.Teaspoon
                    },
                    new IngredientBO()
                    {
                        Id = 5,
                        ProductId = 10, 
                        Quantity = 0.5m,
                        RecipeId = 1,
                        UnitType = Enums.UnitTypes.Teaspoon
                    }
                }
            );

            recipeOne.Ingredients = ingredients;

            return recipeOne;
        }

        private RecipeBO CreateRecipeTwo()
        {
            var recipeTwo = new RecipeBO()
            {
                Id = 2,
                RecipeName = "RecipeTwo"
            };
            var ingredients = new List<IngredientBO>();

            ingredients.AddRange
            (
                new IngredientBO[]
                {
                    new IngredientBO()
                    {
                        Id = 6,
                        ProductId = 1, 
                        Quantity = 1,
                        RecipeId = 2,
                        UnitType = Enums.UnitTypes.Clove
                    },
                    new IngredientBO()
                    {
                        Id = 7,
                        ProductId = 4, 
                        Quantity = 4,
                        RecipeId = 2,
                        UnitType = Enums.UnitTypes.None
                    },
                    new IngredientBO()
                    {
                        Id = 8,
                        ProductId = 7, 
                        Quantity = 0.5m,
                        RecipeId = 2,
                        UnitType = Enums.UnitTypes.Cup
                    },
                    new IngredientBO()
                    {
                        Id = 9,
                        ProductId = 8, 
                        Quantity = 0.5m,
                        RecipeId = 2,
                        UnitType = Enums.UnitTypes.Cup
                    }
                }
            );

            recipeTwo.Ingredients = ingredients;

            return recipeTwo;
        }

        private RecipeBO CreateRecipeThree()
        {
            var recipeThree = new RecipeBO()
            {
                Id = 3,
                RecipeName = "RecipeThree"
            };
            var ingredients = new List<IngredientBO>();

            ingredients.AddRange
            (
                new IngredientBO[]
                {
                    new IngredientBO()
                    {
                        Id = 10,
                        ProductId = 1, 
                        Quantity = 1,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Clove
                    },
                    new IngredientBO()
                    {
                        Id = 11,
                        ProductId = 3, 
                        Quantity = 4,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Cup
                    },
                    new IngredientBO()
                    {
                        Id = 12,
                        ProductId = 5, 
                        Quantity = 4,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Slice
                    },
                    new IngredientBO()
                    {
                        Id = 13,
                        ProductId = 6, 
                        Quantity = 8,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Ounce
                    },
                    new IngredientBO()
                    {
                        Id = 14,
                        ProductId = 7, 
                        Quantity = 0.33333333333m,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Cup
                    },
                    new IngredientBO()
                    {
                        Id = 15,
                        ProductId = 9, 
                        Quantity = 1.25m,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Teaspoon
                    },
                    new IngredientBO()
                    {
                        Id = 16,
                        ProductId = 10, 
                        Quantity = 0.75m,
                        RecipeId = 3,
                        UnitType = Enums.UnitTypes.Teaspoon
                    }
                }
            );

            recipeThree.Ingredients = ingredients;

            return recipeThree;
        }

        private void PrintReceiptToOutput(List<ReceiptItemBO> receiptItems, TotalsBO receiptTotals)
        {
            var output = new StringBuilder();

            var stringFormat = "{0,-14} | {1,-10} | {2,-14} | {3,-12} | {4,-11} | {5,-16} | {6,-10} | {7,-14} | {8,-10}";
            output.Append(
                Environment.NewLine + Environment.NewLine +
                String.Format(stringFormat,
                "Quantity",
                "UnitType",
                "ProductName",
                "ProductPrice",
                "ProductType",
                "WellnessDiscount",
                "ItemTax",
                "BeforeTaxTotal",
                "ItemTotal")
            ).AppendLine();

            output.Append("-------------------------------------------------------------------------------------------------------------------------------------").AppendLine();

            foreach (var item in receiptItems)
            {
                output.Append(
                    String.Format(stringFormat,
                    item.Quantity,
                    item.UnitType,
                    item.ProductName,
                    item.ProductPrice,
                    item.ProductType,
                    item.WellnessDiscount,
                    item.ItemTax,
                    item.BeforeTaxTotal,
                    item.ItemTotal)
                    ).AppendLine();
            }

            output.AppendLine().AppendLine();

            output.Append(
                "Tax = " + receiptTotals.TaxSum
                + Environment.NewLine +
                "Discount = " + receiptTotals.DiscountSum
                + Environment.NewLine +
                "Total = " + receiptTotals.TotalSum
                ).AppendLine().AppendLine();

            Trace.WriteLine(output.ToString());
        }
    }
}
