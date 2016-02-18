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
    public interface IRecipe : IEntity<long>
    {
        string RecipeName { get; set; }
    }

    public class Recipe : IRecipe
    {
        [Key, Required]
        public long Id { get; set; }
        [Required]
        public string RecipeName { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
