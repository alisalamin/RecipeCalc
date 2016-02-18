namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateAndUpdate10 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ingredients", new[] { "RecipeID" });
            CreateIndex("dbo.Ingredients", "RecipeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            CreateIndex("dbo.Ingredients", "RecipeID");
        }
    }
}
