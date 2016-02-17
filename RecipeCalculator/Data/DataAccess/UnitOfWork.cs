using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Models;


namespace DataAccess
{
    internal class UnitOfWork : DbContext
    {
        public UnitOfWork()
            : base("name=RecipeMakerDB")
        { }

        public IDbSet<Ingredient> Ingredients { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<RateAdjustment> RateAdjustments { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<ApplicationConfig> ApplicationConfigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateAdjustment>().Property(ra => ra.SalesTax).HasPrecision(10, 8);
            modelBuilder.Entity<RateAdjustment>().Property(ra => ra.WellnessDiscountRate).HasPrecision(10, 8);

            /* - advanced example -
              mb.Entity<SomeObject>()
            .Property(so => so.Type)
            .IsUnicode(false)
            .HasColumnName("Type")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             */
        }

    }
}
