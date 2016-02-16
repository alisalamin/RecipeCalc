namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.UnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.UnitOfWork context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //Create Basic App Data for Testing
            context.RateAdjustments.AddOrUpdate(
                ra => ra.Id,
                  new RateAdjustment
                  {
                      SalesTax = 0.086m,
                      WellnessDiscountRate = 0.05m
                  }
                );

            context.Products.AddOrUpdate(
                p => p.Id,
                new Product
                {
                    IsOrganic = true,
                    Price = 0.67m,
                    ProductName = "Garlic",
                    ProductType = ProductTypes.Produce,
                    UnitType = UnitTypes.Clove
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 2.03m,
                    ProductName = "Lemon",
                    ProductType = ProductTypes.Produce,
                    UnitType = UnitTypes.None
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 0.87m,
                    ProductName = "Corn",
                    ProductType = ProductTypes.Produce,
                    UnitType = UnitTypes.Cup
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 2.19m,
                    ProductName = "Chicken Breast",
                    ProductType = ProductTypes.Meat,
                    UnitType = UnitTypes.None
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 0.24m,
                    ProductName = "Bacon",
                    ProductType = ProductTypes.Meat,
                    UnitType = UnitTypes.Slice
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 0.31m,
                    ProductName = "Pasta",
                    ProductType = ProductTypes.Pantry,
                    UnitType = UnitTypes.Ounce
                },
                new Product
                {
                    IsOrganic = true,
                    Price = 1.92m,
                    ProductName = "Olive Oil",
                    ProductType = ProductTypes.Pantry,
                    UnitType = UnitTypes.Cup
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 1.26m,
                    ProductName = "Vinegar",
                    ProductType = ProductTypes.Pantry,
                    UnitType = UnitTypes.Cup
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 0.16m,
                    ProductName = "Salt",
                    ProductType = ProductTypes.Pantry,
                    UnitType = UnitTypes.Teaspoon
                },
                new Product
                {
                    IsOrganic = false,
                    Price = 0.17m,
                    ProductName = "Pepper",
                    ProductType = ProductTypes.Pantry,
                    UnitType = UnitTypes.Teaspoon
                }
               );

        }
    }
}
