namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Common;

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
            context.ApplicationConfigs.AddOrUpdate(
                ac => ac.Id,
                new ApplicationConfig
                {
                    Id = Guid.Parse("bd1ed0f5-64d5-e511-9866-c713c0429be9"),
                    AppName = "RecipeCalculator"
                }
               );

            context.RateAdjustments.AddOrUpdate(
                ra => ra.Id,
                new RateAdjustment
                {
                    Id = 1,
                    AppId = Guid.Parse("bd1ed0f5-64d5-e511-9866-c713c0429be9"),
                    SalesTax = 8.6m,
                    WellnessDiscountRate = 5.0m
                }
               );

            context.Products.AddOrUpdate(
                p => p.Id,
                new Product
                {
                    Id = 1,
                    IsOrganic = true,
                    Price = 0.67m,
                    ProductName = "Garlic",
                    ProductType = Enums.ProductTypes.Produce,
                    UnitType = Enums.UnitTypes.Clove
                },
                new Product
                {
                    Id = 2,
                    IsOrganic = false,
                    Price = 2.03m,
                    ProductName = "Lemon",
                    ProductType = Enums.ProductTypes.Produce,
                    UnitType = Enums.UnitTypes.None
                },
                new Product
                {
                    Id = 3,
                    IsOrganic = false,
                    Price = 0.87m,
                    ProductName = "Corn",
                    ProductType = Enums.ProductTypes.Produce,
                    UnitType = Enums.UnitTypes.Cup
                },
                new Product
                {
                    Id = 4,
                    IsOrganic = false,
                    Price = 2.19m,
                    ProductName = "Chicken Breast",
                    ProductType = Enums.ProductTypes.Meat,
                    UnitType = Enums.UnitTypes.None
                },
                new Product
                {
                    Id = 5,
                    IsOrganic = false,
                    Price = 0.24m,
                    ProductName = "Bacon",
                    ProductType = Enums.ProductTypes.Meat,
                    UnitType = Enums.UnitTypes.Slice
                },
                new Product
                {
                    Id = 6,
                    IsOrganic = false,
                    Price = 0.31m,
                    ProductName = "Pasta",
                    ProductType = Enums.ProductTypes.Pantry,
                    UnitType = Enums.UnitTypes.Ounce
                },
                new Product
                {
                    Id = 7,
                    IsOrganic = true,
                    Price = 1.92m,
                    ProductName = "Olive Oil",
                    ProductType = Enums.ProductTypes.Pantry,
                    UnitType = Enums.UnitTypes.Cup
                },
                new Product
                {
                    Id = 8,
                    IsOrganic = false,
                    Price = 1.26m,
                    ProductName = "Vinegar",
                    ProductType = Enums.ProductTypes.Pantry,
                    UnitType = Enums.UnitTypes.Cup
                },
                new Product
                {
                    Id = 9,
                    IsOrganic = false,
                    Price = 0.16m,
                    ProductName = "Salt",
                    ProductType = Enums.ProductTypes.Pantry,
                    UnitType = Enums.UnitTypes.Teaspoon
                },
                new Product
                {
                    Id = 10,
                    IsOrganic = false,
                    Price = 0.17m,
                    ProductName = "Pepper",
                    ProductType = Enums.ProductTypes.Pantry,
                    UnitType = Enums.UnitTypes.Teaspoon
                }
               );

        }
    }
}
