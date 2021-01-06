using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbFiller
{
    public class DbOperations
    {
        private GwDbContext context;

        public DbOperations(string connectionString)
        {
            context = new GwDbContext(connectionString);
        }
        public async Task ClearDb()
        {
            DeleteAllEntity<Account>();
            DeleteAllEntity<Armor>();
            DeleteAllEntity<BackItem>();
            DeleteAllEntity<Consumable>();
            DeleteAllEntity<Container>();
            DeleteAllEntity<GatheringTool>();
            DeleteAllEntity<Gizmo>();
            DeleteAllEntity<Item>();
            DeleteAllEntity<Listing>();
            DeleteAllEntity<Miniature>();
            DeleteAllEntity<SalvageKit>();
            DeleteAllEntity<Skin>();
            DeleteAllEntity<TPListing>();
            DeleteAllEntity<Trinket>();
            DeleteAllEntity<UpgradeComponent>();
            DeleteAllEntity<Weapon>();
            await context.SaveChangesAsync();
        }

        public void DeleteAllEntity<T>() where T : class
        {
            var set = context.Set<T>();
            context.RemoveRange(context.Set<T>());
        }

        public async Task AddToEntity<T>(List<T> itemsToAdd) where T : class
        {
            context.Set<T>().AddRange(itemsToAdd);
            await context.SaveChangesAsync();
        }
    }
}
