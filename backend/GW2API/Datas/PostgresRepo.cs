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

        public void AddCommandLog(CommandLog commandLog)
        {
            _context.CommandLogs.Add(commandLog);
        }

        public void AddListings(IEnumerable<Listing> listings)
        {
            foreach (var listing in listings)
            {
                if(listing.ItemId > 0 && _context.Items.FirstOrDefault(v => v.Id == listing.ItemId) != null)
                    _context.Listings.Add(listing);
                else
                {
                    int count =_context.Listings.Count();
                }
            }
        }

        public void AddRecipePrice(RecipePrice recipePrice)
        {
            _context.RecipePrices.Add(recipePrice);
        }

        public IEnumerable<Item> GetAllItems() => _context.Items;
        public IEnumerable<Recipe> GetAllRecipes() => _context.Recipes;
        public CommandLog GetLatestLog() => _context.CommandLogs.FirstOrDefault(v => v.LastUpdate == _context.CommandLogs.Max(v => v.LastUpdate));
        public CommandLog GetLogById(int id) => _context.CommandLogs.FirstOrDefault(v => v.Id == id);
        public int GetRecipePricesCount() => _context.RecipePrices.Count();
        public int GetTpPricesCount() => _context.Listings.Count();
        public int GetListingsCount() => _context.Listings.Count();
        public bool SaveChanges() => (_context.SaveChanges() >= 0);
    }
}
