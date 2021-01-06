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
        public const string ITEM_SUFFIX = "items";
        public const string SKINS_SUFFIX = "skins";
        public const string ADDITIONAL_INFO_KEY = "dtails";
        public const string CONNECTION_STRING = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=GW2;Pooling=true;Connection Lifetime=0;";

        private static DbOperations dbOperations;
        private static APIOperations apiOperations;
        public static async Task Main(string[] args)
        {
            dbOperations = new DbOperations(CONNECTION_STRING);
            apiOperations = new APIOperations(API_URL);
            //await dbOperations.ClearDb();
            //await GetSkins();
            await GetItems();
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
            List<Skin> allItems = new List<Skin>();
            List<int> allIds = apiOperations.GetAllIds(ITEM_SUFFIX);

            Console.WriteLine($"Got {allIds.Count} items Ids");
        }
    }
}
