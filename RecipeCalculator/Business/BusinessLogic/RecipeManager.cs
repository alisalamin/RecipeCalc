using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Models;
using Common;

namespace BusinessLogic
{
    class RecipeManager : BaseManager
    {
        public RecipeBO GetRecipeById(long recipeID)
        {
            var recipe = new Repository<Recipe, long>().GetById(recipeID);
            var ingredientList = new List<IngredientBO>();

            ingredientList = recipe.Ingredients
                .Select
                (
                  dto => new IngredientBO()
                  {
                      Id = dto.Id,
                      ProductId = dto.ProductId,
                      Quantity = dto.Quantity,
                      RecipeId = dto.RecipeId,
                      UnitType = dto.UnitType
                  }
                ).ToList();

            return new RecipeBO()
            {
                Id = recipe.Id,
                Ingredients = ingredientList,
                RecipeName = recipe.RecipeName
            };
        }

        public void CreateRecipe()
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe()
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe()
        {
            throw new NotImplementedException();
        }
    }
}
