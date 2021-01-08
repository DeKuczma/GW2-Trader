using BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using GW2API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Datas
{
    public class PostgresRepo : IRepo
    {
        private readonly PostgresContext _context;
        public PostgresRepo(PostgresContext context)
        {
            _context = context;
        }

        public void AddRecipePrice(RecipePrice recipePrice)
        {
            _context.RecipePrices.Add(recipePrice);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
