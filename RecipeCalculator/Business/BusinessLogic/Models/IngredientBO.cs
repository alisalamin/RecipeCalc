using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BusinessLogic.Models
{
    public class IngredientBO 
    {
        public long Id { get; set; }

        public long RecipeID { get; set; }

        public decimal Quantity { get; set; }

        public Enums.UnitTypes UnitType { get; set; }

        public long ProductId { get; set; }
    }
}
