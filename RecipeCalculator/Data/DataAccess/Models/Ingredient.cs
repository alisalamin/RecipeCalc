using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Models
{
    public enum UnitTypes
    {
        None = 0,
        Ounce = 1,
        Slice = 2,
        Teaspoon = 3,
        Clove = 4,
        Cup = 5
    }

    public interface IIngredient : IEntity<long>
    {
        long RecipeID { get; set; }
        decimal AmountOf { get; set; }
        UnitTypes UnitType { get; set; }
        IProduct Product { get; set; }
    }

    public class Ingredient : IIngredient
    {
        [Key, Required]
        public long Id { get; set; }
        
        [Required]
        public decimal AmountOf { get; set; }
        [Required]
        public UnitTypes UnitType { get; set; }
        [Required]
        public IProduct Product { get; set; }

        [ForeignKey("Recipe")]
        public long RecipeID { get; set; }
        public Recipe Recipe { get; set; } 
    }
}
