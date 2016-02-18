using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Models;
using Common;

namespace BusinessLogic
{
    public class RecipeCalculator : BaseManager
    {
        public decimal BeforeTaxPrice(IngredientBO ingredient)
        {
            var product = new Repository<Product, long>().GetById(ingredient.ProductId);

            return Math.Round((ingredient.Quantity * product.Price), 2);
        }

        public decimal ApplyWellnessDiscount(decimal amount)
        {
           // return (amount - Math.Round(amount * (AppSettings.WellnessDiscountRate / 100), 2));
            return amount - amount * (AppSettings.WellnessDiscountRate / 100);
        }

        public decimal ApplySalesTax(decimal amount)
        {
            return (amount + Math.Round(amount * (AppSettings.SalesTax / 100), 2));
        }

        public TotalsBO TotalCost(List<ReceiptItemBO> receipt)
        {
            return new TotalsBO()
            {
                DiscountSum = Math.Round(receipt.Sum(r => r.WellnessDiscount), 2),
                TaxSum = Math.Round(receipt.Sum(r => r.ItemTax), 2),
                TotalSum = Math.Round(receipt.Sum(r => r.ItemTotal), 2)
            };

        }

        public List<ReceiptItemBO> CreateRecipeReceipt(RecipeBO recipe)
        {
            var receipt = new List<ReceiptItemBO>();

            foreach (var ingr in recipe.Ingredients)
            {
                var beforeTax = BeforeTaxPrice(ingr);
                var product = new Repository<Product, long>().GetById(ingr.ProductId);
                var wellnessDiscountAmount = ((product.IsOrganic) ? Math.Round(beforeTax * (AppSettings.WellnessDiscountRate / 100), 2): 0.00m);
                var itemTaxAmount = ((product.ProductType != Enums.ProductTypes.Produce) ? (Math.Round(beforeTax * (AppSettings.SalesTax / 100), 2)) : 0.00m);

                receipt.Add(
                    new ReceiptItemBO()
                    {
                        Quantity = ingr.Quantity,
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        UnitType = ingr.UnitType,
                        ProductPrice = product.Price,
                        ProductType = product.ProductType,
                        WellnessDiscount = wellnessDiscountAmount,
                        ItemTax = itemTaxAmount,
                        BeforeTaxTotal = Math.Round(beforeTax, 2),
                        ItemTotal = Math.Round((beforeTax - wellnessDiscountAmount) + itemTaxAmount, 2)

                    }
                 );
            }

            return receipt;
        }
    }
}
