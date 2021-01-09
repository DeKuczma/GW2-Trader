using BaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GW2API.APICalls
{
    public class GwApiCalls : IApiCalls
    {
        private readonly HttpClient _client = new HttpClient();
        public const string API_URL = "https://api.guildwars2.com/v2/";
        public const string LISTING_SUFFIX = "commerce/listings";
        public GwApiCalls()
        {
            _client.BaseAddress = new Uri(API_URL);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<Listing>> GetAllListings()
        {
            List<Listing> resultListings = new List<Listing>();
            HttpResponseMessage response = await _client.GetAsync(LISTING_SUFFIX);
            if (!response.IsSuccessStatusCode)
                return null;

            List<int> availableIds = JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync());
            for(int i = 0; i < availableIds.Count; i += 200)
            {
                IEnumerable<int> idsToDownload = availableIds.Skip(i).Take(200);
                StringBuilder endpoint = new StringBuilder(LISTING_SUFFIX).Append("?ids=");
                foreach (var id in idsToDownload)
                    endpoint.Append(id)
                        .Append(',');
                endpoint.Length--;

                response = await _client.GetAsync(endpoint.ToString());

                string listingsResponse = (await response.Content.ReadAsStringAsync()).Replace("id", "ItemId");
                resultListings.AddRange(GetObjectsFromJson<Listing>(listingsResponse));
            }
            return resultListings;
        }

        private static IEnumerable<T> GetObjectsFromJson<T>(string objectString)
        {
            objectString = objectString.Replace("_", string.Empty);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(objectString);
        }
    }
}
