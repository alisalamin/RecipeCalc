using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DataAccess.Models
{
    public interface IRecipe : IEntity<int>
    {
        string RecipeName { get; set; }
    }

    public class Recipe : IRecipe
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string RecipeName { get; set; }
    }
}
