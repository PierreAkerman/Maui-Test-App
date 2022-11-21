using MobileAppMaui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppMaui.Services
{
    public class ErrandService : IErrandService
    {
        public static readonly string baseUrl = "http://localhost:7197/api/technicianErrand";

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

        public async Task<List<ErrandModel>> GetErrandsFromTechnicianIdAsync()
        {
            Errands = new List<ErrandModel>();

            //var uri = new Uri(string.Format($"{baseUrl}/technicianErrand", string.Empty));

            try
            {
                var response = await _client.GetAsync(baseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Errands = JsonSerializer.Deserialize<List<ElevatorListModel>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }
        
    }
}
