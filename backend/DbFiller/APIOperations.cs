using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DbFiller
{
    public class APIOperations
    {
        private HttpClient Client { get; set; }

        public APIOperations(string apiAdress)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(apiAdress);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<int> GetAllIds(string endpoint)
        {
            List<int> recievedIds = new List<int>();

            HttpResponseMessage response;
            response = Client.GetAsync(endpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string idsResponse = response.Content.ReadAsStringAsync().Result;
                recievedIds = JsonConvert.DeserializeObject<List<int>>(idsResponse);
            }
            return recievedIds;
        }

        public APIResult<T> GetSingleObjctById<T>(string endpoint) where T : class
        {
            HttpResponseMessage response = Client.GetAsync(endpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                return GetObjectFromJson<T>(responseString);
            }
            return null;
        }

        public List<APIResult<T>> GetObjectsByIds<T>(string endpoint)
        {
            List<APIResult<T>> result = new List<APIResult<T>>();
            HttpResponseMessage response = Client.GetAsync(endpoint).Result;
            
            if(response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.Linq.JArray objArray = Newtonsoft.Json.Linq.JArray.Parse(content);
                foreach (var objJson in objArray)
                {
                    string serializedObjct = JsonConvert.SerializeObject(objJson);
                    result.Add(GetObjectFromJson<T>(serializedObjct));
                }
            }

            return result;
        }

        private static APIResult<T> GetObjectFromJson<T>(string objectString)
        {
            string details = "";
            T obj;
            objectString = objectString.Replace("_", string.Empty);
            Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(objectString);
            if (json.ContainsKey(Program.ADDITIONAL_INFO_KEY))
                details = json.GetValue(Program.ADDITIONAL_INFO_KEY).ToString();
            obj = JsonConvert.DeserializeObject<T>(objectString);
            return new APIResult<T>(obj, details);
        }
    }
}
