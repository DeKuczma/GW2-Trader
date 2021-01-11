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

        public List<TPListing> GetItemBuyOrder(int itemId)
        {

            Listing listing = _context.Listings.FirstOrDefault(l => l.ItemId == itemId);
            if (listing == null)
                return null;
            else
                return listing.Buys;
        }

        public List<TPListing> GetItemSellOrder(int itemId)
        {
            Listing listing = _context.Listings.FirstOrDefault(l => l.ItemId == itemId);
            if (listing == null)
                return null;
            else
                return listing.Sells;
        }

        public void ClearListings()
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM \"RecipePrices\"");
            _context.Database.ExecuteSqlRaw("DELETE FROM \"Listings\"");
        }

        public IEnumerable<RecipePrice> GetAllRecipePrices()
        {
            return _context.RecipePrices.ToList();
        }

        public RecipePrice GetRecipePriceById(int id)
        {
            return _context.RecipePrices.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<RecipePrice> GetRecipePriceByBuyNowProfit()
        {
            return _context.RecipePrices.Where(v => v.CreationPriceBuyNow > 0);
        }

        public IEnumerable<RecipePrice> GetRecipePriceByBuyOrderProfit()
        {
            return _context.RecipePrices.Where(v => v.CreationPriceBuyOrder > 0);
        }

        public Item GetItemById(int id) => _context.Items.FirstOrDefault(v => v.Id == id);
    }
}
