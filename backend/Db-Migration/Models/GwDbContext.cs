using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db_Models;

namespace Db_Migration.Models
{
    public class GwDbContext : DbContext
    {
        public GwDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<BackItem> BackItems { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<GatheringTool> GatheringTools { get; set; }
        public DbSet<Gizmo> Gizmos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Miniature> Miniatures { get; set; }
        public DbSet<SalvageKit> SalvageKits { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<TPListing> TPListings { get; set; }
        public DbSet<Trinket> Trinkets { get; set; }
        public DbSet<UpgradeComponent> UpgradeComponents { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
