using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GW2API.Models
{
    public class PostgresContext : DbContext
    {

        public PostgresContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //item class
            builder.Entity<Item>()
                .Property(e => e.Flags)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<Item>()
                .Property(e => e.GameTypes)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<Item>()
                .Property(e => e.Restrictions)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            //Armor class
            builder.Entity<Armor>()
                .Property(e => e.StatChoices)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));

            //BackItem class
            builder.Entity<BackItem>()
                .Property(e => e.StatChoices)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));

            //Consumable class
            builder.Entity<Consumable>()
                .Property(e => e.Skins)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));
            builder.Entity<Consumable>()
                .Property(e => e.ExtraRecipeIds)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));

            //Gizmo class
            builder.Entity<Gizmo>()
                .Property(e => e.VendorIds)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));

            //Listing class
            builder.Entity<Listing>()
                .Property(e => e.BuyListing)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<TPListing>>(v));
            builder.Entity<Listing>()
                .Property(e => e.SellListing)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<TPListing>>(v));

            //Skin class
            builder.Entity<Skin>()
                .Property(e => e.Flags)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<Skin>()
                .Property(e => e.Restrictions)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            //Trinket class
            builder.Entity<Trinket>()
                .Property(e => e.StatChoices)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));

            //UpgradeCOmponent class
            builder.Entity<UpgradeComponent>()
                .Property(e => e.Flags)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<UpgradeComponent>()
                .Property(e => e.InfusionUpgradeFlags)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<UpgradeComponent>()
                .Property(e => e.Bonuses)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            //Weapon class
            builder.Entity<Weapon>()
                .Property(e => e.StatChoices)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<int>>(v));
            //Recipes class
            builder.Entity<Recipe>()
                .Property(e => e.Disciplines)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<Recipe>()
                .Property(e => e.Flags)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Entity<Recipe>()
                .Property(e => e.Ingredients)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<Ingredient>>(v));
            builder.Entity<Recipe>()
                .Property(e => e.GuildIngredients)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<Ingredient>>(v));
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
        public DbSet<Trinket> Trinkets { get; set; }
        public DbSet<UpgradeComponent> UpgradeComponents { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipePrice> RecipePrices { get; set; }
        public DbSet<CommandExecutionLog> CommandExecutionLogs { get; set; }
    }
}
