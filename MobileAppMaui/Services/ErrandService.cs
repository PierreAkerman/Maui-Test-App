using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MobileAppMaui.Data;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Net.Mime;

namespace MobileAppMaui.Services
{
    public class ErrandService : IErrandService
    {
        //public static readonly string baseUrl = "http://localhost:7197/api/technicianErrand";

        public readonly HttpClient _client;
        public readonly JsonSerializerOptions _serializerOptions;

        public List<ErrandModel> Errands { get; set; }

        public ErrandService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id)
        {
            Errands = new List<ErrandModel>();

            //id = "4d91ae92-e9cd-4af1-bb33-432ce12d5864";



            var uri = new Uri(string.Format($"https://grupp3azurefunctions.azurewebsites.net/api/technicianErrand?id={id}", string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Errands = JsonConvert.DeserializeObject<List<ErrandModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Errands;
        }
        
    }
}
