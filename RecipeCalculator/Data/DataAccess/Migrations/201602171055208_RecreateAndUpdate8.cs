namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateAndUpdate8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationConfigs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AppName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitType = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        RecipeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        ProductType = c.Int(nullable: false),
                        UnitType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsOrganic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RateAdjustments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesTax = c.Decimal(nullable: false, precision: 10, scale: 8),
                        WellnessDiscountRate = c.Decimal(nullable: false, precision: 10, scale: 8),
                        AppId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationConfigs", t => t.AppId, cascadeDelete: true)
                .Index(t => t.AppId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RateAdjustments", "AppId", "dbo.ApplicationConfigs");
            DropForeignKey("dbo.Ingredients", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RateAdjustments", new[] { "AppId" });
            DropIndex("dbo.Ingredients", new[] { "RecipeID" });
            DropTable("dbo.RateAdjustments");
            DropTable("dbo.Products");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.ApplicationConfigs");
        }
    }
}
