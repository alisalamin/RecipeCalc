using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using Common;

namespace BusinessLogic.Models
{
    public class RecipeBO
    {
        public long Id { get; set; }
        public string RecipeName { get; set; }
        public ICollection<IngredientBO> Ingredients {get; set;}
    }
}
