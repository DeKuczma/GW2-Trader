using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFiller.Models;

namespace DbFiller
{
    public class DbOperations
    {
        public PostgresContext Context { get; set; }

        public DbOperations(string connectionString)
        {
            Context = new PostgresContext(connectionString);
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
            DeleteAllEntity<Trinket>();
            DeleteAllEntity<UpgradeComponent>();
            DeleteAllEntity<Weapon>();
            await Context.SaveChangesAsync();
        }

        public void DeleteAllEntity<T>() where T : class
        {
            var set = Context.Set<T>();
            Context.RemoveRange(Context.Set<T>());
        }

        public async Task AddToEntity<T>(List<T> itemsToAdd) where T : class
        {
            Context.Set<T>().AddRange(itemsToAdd);
            await Context.SaveChangesAsync();
        }

        public void AddWithoutCommit<T>(T objectToAdd) where T : class
        {
            Context.Set<T>().Add(objectToAdd);
        }

        public async Task AddWithCommit<T>(T objectToAdd) where T : class
        {
            AddWithoutCommit<T>(objectToAdd);
            await Context.SaveChangesAsync();
        }

        public async Task CommitChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
