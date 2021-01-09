using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModels;

namespace GW2API.Datas
{
    public interface IRepo
    {
        public bool SaveChanges();
        public IEnumerable<Recipe> GetAllRecipes();
        public IEnumerable<Item> GetAllItems();
        public void AddRecipePrice(RecipePrice recipePrice);
        public CommandLog GetLatestLog();
        public CommandLog GetLogById(int id);
        public int GetRecipePricesCount();
        public int GetTpPricesCount();
        public void AddListings(IEnumerable<Listing> listings);
        public void AddCommandLog(CommandLog commandLog);
    }
}
