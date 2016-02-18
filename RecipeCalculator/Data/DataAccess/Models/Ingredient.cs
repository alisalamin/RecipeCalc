using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace DataAccess.Models
{
    public interface IIngredient : IEntity<long>
    {
        long RecipeId { get; set; }
        decimal Quantity { get; set; }
        Enums.UnitTypes UnitType { get; set; }
        long ProductId { get; set; }
    }

    public class Ingredient : IIngredient
    {
        [Key, Required]
        public long Id { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Enums.UnitTypes UnitType { get; set; }
        [Required]
        public long ProductId { get; set; }

        [ForeignKey("Recipe")]
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; } 
    }
}
