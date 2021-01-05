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

namespace DbFiller
{
    public class Program
    {
        public const string API_URL = "https://api.guildwars2.com/v2/";
        public const string ITEM_SUFFIX = "items";
        public const string SKINS_SUFFIX = "skins";
        public const string ADDITIONAL_INFO_KEY = "dtails";
        public const string CONNECTION_STRING = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=GW2;Pooling=true;Connection Lifetime=0;";
        public static void Main(string[] args)
        {
            ClearDb();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GetSkins(client);
            GetItems(client);
        }

        public static void GetSkins(HttpClient client)
        {
            List<Skin> allSkins = new List<Skin>();
            List<int> allIds = GetAllIds(client, SKINS_SUFFIX);

            foreach(var id in allIds)
            {
                Skin skin = GetSingleObjctById<Skin>(client, SKINS_SUFFIX + "/" + id.ToString(), out string details);
                if (skin != null)
                {
                    allSkins.Add(skin);
                    if (allSkins.Count == 10)
                        break;
                }
            }

            using GwDbContext context = new GwDbContext(CONNECTION_STRING);
            context.AddRange(allSkins);
            context.SaveChanges();
        }

        public static void ClearDb()
        {   
            using (GwDbContext context = new GwDbContext(CONNECTION_STRING))
            {
                DeleteAll<Account>(context);
                DeleteAll<Armor>(context);
                DeleteAll<BackItem>(context);
                DeleteAll<Consumable>(context);
                DeleteAll<Container>(context);
                DeleteAll<GatheringTool>(context);
                DeleteAll<Gizmo>(context);
                DeleteAll<Item>(context);
                DeleteAll<Listing>(context);
                DeleteAll<Miniature>(context);
                DeleteAll<SalvageKit>(context);
                DeleteAll<Skin>(context);
                DeleteAll<TPListing>(context);
                DeleteAll<Trinket>(context);
                DeleteAll<UpgradeComponent>(context);
                DeleteAll<Weapon>(context);
            }
        }

        public static void DeleteAll<T>(DbContext context) where T : class
        {
            context.RemoveRange(context.Set<T>());
        }

        public static void GetItems(HttpClient client)
        {

        }

        public static List<int> GetAllIds(HttpClient client, String endpoint)
        {
            List<int> recievedIds = new List<int>();

            HttpResponseMessage response;
            response = client.GetAsync(endpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string idsResponse = response.Content.ReadAsStringAsync().Result;
                recievedIds = JsonConvert.DeserializeObject<List<int>>(idsResponse);
            }
            return recievedIds;
        }

        public static T GetSingleObjctById<T>(HttpClient client, string endpoint, out string details) where T : class
        {
            HttpResponseMessage response = client.GetAsync(endpoint).Result; ;
            details = "";

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                if (json.ContainsKey(ADDITIONAL_INFO_KEY))
                    details = json.GetValue(ADDITIONAL_INFO_KEY).ToString();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            return null;
        }
    }
}
