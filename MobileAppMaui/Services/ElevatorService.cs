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
    public class ElevatorService : IElevatorService
    {
        public static readonly string baseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        public readonly HttpClient _client;
        public readonly JsonSerializerOptions _serializerOptions;

        public List<ElevatorDetailsModel> Items { get; set; }
        public ElevatorDetailsModel Item { get; private set; }

        public ElevatorService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<IEnumerable<ElevatorDetailsModel>> GetAllElevatorsAsync()
        {
            Items = new List<ElevatorDetailsModel>();

            var uri = new Uri(string.Format($"{baseUrl}/elevator/all/detailed?", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<ElevatorDetailsModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }

        public async Task<ElevatorDetailsModel> GetElevatorByIdAsync(string id)
        {
            Item = new ElevatorDetailsModel();

            var uri = new Uri(string.Format($"{baseUrl}/elevator?id={id}", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ElevatorDetailsModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Item;
        }
    }
}
