using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BaseModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text;

namespace DbFiller
{
    public class Program
    {
        public const string API_URL = "https://api.guildwars2.com/v2/";
        public const string ITEMS_SUFFIX = "items";
        public const string SKINS_SUFFIX = "skins";
        public const string RECIPES_SUFFIX = "recipes";
        public const string ADDITIONAL_INFO_KEY = "details";
        public const string CONNECTION_STRING = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=GW2;Pooling=true;Connection Lifetime=0;";

        private static DbOperations dbOperations;
        private static APIOperations apiOperations;
        public static async Task Main(string[] args)
        {
            dbOperations = new DbOperations(CONNECTION_STRING);
            apiOperations = new APIOperations(API_URL);
            //await dbOperations.ClearDb();
            //await GetSkins();
            //await GetItems();
            await GetRecipes();
        }

        public static async Task GetSkins()
        {
            List<Skin> allSkins = new List<Skin>();
            List<int> allIds = apiOperations.GetAllIds(SKINS_SUFFIX);

            Console.WriteLine($"Got {allIds.Count} skin Ids");

            for(int i = 0; i < allIds.Count; i += 200)
            {
                IEnumerable<int> idsToDownload = allIds.Skip(i).Take(200);
                StringBuilder endpoint = new StringBuilder(SKINS_SUFFIX).Append("?ids=");
                foreach(var id in idsToDownload)
                    endpoint.Append(id)
                        .Append(',');
                endpoint.Length--;
                List<APIResult<Skin>> result = apiOperations.GetObjectsByIds<Skin>(endpoint.ToString());
                foreach(var apiSkin in result)
                    allSkins.Add(apiSkin.ResultObject);
                Console.WriteLine($"Loaded {allSkins.Count} out of {allIds.Count} skins");
            }
            await dbOperations.AddToEntity<Skin>(allSkins);

            Console.WriteLine("Getting skins completed");
        }

        public static async Task GetItems()
        {
            List<Item> allItems = new List<Item>();
            List<int> allIds = apiOperations.GetAllIds(ITEMS_SUFFIX);

            Console.WriteLine($"Got {allIds.Count} items Ids");

            for (int i = 0; i < allIds.Count; i += 200)
            {
                IEnumerable<int> idsToDownload = allIds.Skip(i).Take(200);
                StringBuilder endpoint = new StringBuilder(ITEMS_SUFFIX).Append("?ids=");
                foreach (var id in idsToDownload)
                    endpoint.Append(id)
                        .Append(',');
                endpoint.Length--;
                List<APIResult<Item>> result = apiOperations.GetObjectsByIds<Item>(endpoint.ToString());

                foreach (var apiItem in result)
                {
                    Item itemToAdd = apiItem.ResultObject;
                    switch(itemToAdd.Type)
                    {
                        case "Armor":
                            Armor armor = JsonConvert.DeserializeObject<Armor>(apiItem.AdditionalDetails);
                            armor.Id = itemToAdd.Id;
                            itemToAdd.Armor = armor;
                            itemToAdd.ArmorId = armor.Id;
                            dbOperations.AddWithoutCommit<Armor>(armor);
                            break;
                        case "Weapon":
                            Weapon weapon = JsonConvert.DeserializeObject<Weapon>(apiItem.AdditionalDetails);
                            weapon.Id = itemToAdd.Id;
                            itemToAdd.Weapon = weapon;
                            itemToAdd.WeaponId = weapon.Id;
                            dbOperations.AddWithoutCommit<Weapon>(weapon);
                            break;
                        case "Back":
                            BackItem backItem = JsonConvert.DeserializeObject<BackItem>(apiItem.AdditionalDetails);
                            if (backItem == null)
                                backItem = new BackItem();
                            backItem.Id = itemToAdd.Id;
                            itemToAdd.BackItem = backItem;
                            itemToAdd.BackItemId = backItem.Id;
                            dbOperations.AddWithoutCommit<BackItem>(backItem);
                            break;
                        case "Consumable":
                            Consumable consumable = JsonConvert.DeserializeObject<Consumable>(apiItem.AdditionalDetails);
                            consumable.Id = itemToAdd.Id;
                            itemToAdd.Consumable = consumable;
                            itemToAdd.ConsumableId = consumable.Id;
                            dbOperations.AddWithoutCommit<Consumable>(consumable);
                            break;
                        case "Container":
                            Container container = JsonConvert.DeserializeObject<Container>(apiItem.AdditionalDetails);
                            container.Id = itemToAdd.Id;
                            itemToAdd.Container = container;
                            itemToAdd.ContainerId = container.Id;
                            dbOperations.AddWithoutCommit<Container>(container);
                            break;
                        case "Gathering":
                            GatheringTool gathering = JsonConvert.DeserializeObject<GatheringTool>(apiItem.AdditionalDetails);
                            gathering.Id = itemToAdd.Id;
                            itemToAdd.GatheringTool= gathering;
                            itemToAdd.GatheringToolId = gathering.Id;
                            dbOperations.AddWithoutCommit<GatheringTool>(gathering);
                            break;
                        case "Gizmo":
                            Gizmo gizmo = JsonConvert.DeserializeObject<Gizmo>(apiItem.AdditionalDetails);
                            gizmo.Id = itemToAdd.Id;
                            itemToAdd.Gizmo = gizmo;
                            itemToAdd.GizmoId = gizmo.Id;
                            dbOperations.AddWithoutCommit<Gizmo>(gizmo);
                            break;
                        case "MiniPet":
                            Miniature mini = JsonConvert.DeserializeObject<Miniature>(apiItem.AdditionalDetails);
                            mini.Id = itemToAdd.Id;
                            itemToAdd.Miniature= mini;
                            itemToAdd.MiniatureId = mini.Id;
                            dbOperations.AddWithoutCommit<Miniature>(mini);
                            break;
                        case "Tool":
                            SalvageKit salvage = JsonConvert.DeserializeObject<SalvageKit>(apiItem.AdditionalDetails);
                            salvage.Id = itemToAdd.Id;
                            itemToAdd.SalvageKit = salvage;
                            itemToAdd.SalvageKitId = salvage.Id;
                            dbOperations.AddWithoutCommit<SalvageKit>(salvage);
                            break;
                        case "Trinket":
                            Trinket trinket = JsonConvert.DeserializeObject<Trinket>(apiItem.AdditionalDetails);
                            trinket.Id = itemToAdd.Id;
                            itemToAdd.Trinket = trinket;
                            itemToAdd.TrinketId = trinket.Id;
                            dbOperations.AddWithoutCommit<Trinket>(trinket);
                            break;
                        case "UpgradeComponent":
                            UpgradeComponent upgrade = JsonConvert.DeserializeObject<UpgradeComponent>(apiItem.AdditionalDetails);
                            upgrade.Id = itemToAdd.Id;
                            itemToAdd.UpgradeComponent = upgrade;
                            itemToAdd.UpgradeComponentId = upgrade.Id;
                            dbOperations.AddWithoutCommit<UpgradeComponent>(upgrade);
                            break;
                        default:
                            break;
                    }
                    allItems.Add(apiItem.ResultObject);
                }
                Console.WriteLine($"Loaded {allItems.Count} out of {allIds.Count} items");
            }

            await dbOperations.AddToEntity<Item>(allItems);

            Console.WriteLine("Getting items completed");
        }


        private static async Task GetRecipes()
        {
            List<Recipe> allRecipes = new List<Recipe>();
            List<int> allIds = apiOperations.GetAllIds(RECIPES_SUFFIX);

            Console.WriteLine($"Got {allIds.Count} recipes Ids");

            for (int i = 0; i < allIds.Count; i += 200)
            {
                IEnumerable<int> idsToDownload = allIds.Skip(i).Take(200);
                StringBuilder endpoint = new StringBuilder(RECIPES_SUFFIX).Append("?ids=");
                foreach (var id in idsToDownload)
                    endpoint.Append(id)
                        .Append(',');
                endpoint.Length--;
                List<APIResult<Recipe>> result = apiOperations.GetObjectsByIds<Recipe>(endpoint.ToString());
                foreach (var apiSkin in result)
                    allRecipes.Add(apiSkin.ResultObject);
                Console.WriteLine($"Loaded {allRecipes.Count} out of {allIds.Count} recipes");
            }

            foreach(Recipe recipe in allRecipes.ToList())
            {
                if(dbOperations.Context.Items.SingleOrDefault(e => e.Id == recipe.OutputItemId) == null)
                    allRecipes.Remove(recipe);
            }
            await dbOperations.AddToEntity<Recipe>(allRecipes);

            Console.WriteLine("Getting skins completed");
        }
    }
}
