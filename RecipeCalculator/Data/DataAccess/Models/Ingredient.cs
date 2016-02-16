using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace DataAccess.Models
{
    public enum UnitTypes
    {
        None = 0,
        Ounce = 1,
        Slice = 2,
        Teaspoon = 3
    }

    public interface IIngredient : IEntity<int>
    {
        decimal AmountOf { get; set; }
        UnitTypes UnitType { get; set; }
        IProduct Product { get; set; }
    }

    public class Ingredient : IIngredient
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public decimal AmountOf { get; set; }
        [Required]
        public UnitTypes UnitType { get; set; }
        [Required]
        public IProduct Product { get; set; }
    }
}
