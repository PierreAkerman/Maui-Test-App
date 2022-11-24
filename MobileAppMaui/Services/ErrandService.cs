using Newtonsoft.Json;
using System.Diagnostics;
using MobileAppMaui.Models;
using System.Net;
using System.Text;

namespace MobileAppMaui.Services
{
    public class ErrandService : IErrandService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;

        public ErrandModel Item { get; set; }
        public List<ErrandModel> Errands { get; set; }

        public ErrandService()
        {
            _client = new HttpClient();
        }

        public async Task<ErrandModel> GetErrandByIdAsync(string id)
        {
            Item = new ErrandModel();

            var uri = new Uri(string.Format($"{BaseUrl}/errand?id={id}", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ErrandModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Item;
        }

        public async Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id)
        {
            Errands = new List<ErrandModel>();

            var uri = new Uri(string.Format($"{BaseUrl}/technicianErrand?id={id}", string.Empty));

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

        public class ChangeErrandStatusModel
        {
            public string ErrandId { get; set;}
            public string Status { get; set;}
        }

        public async Task<HttpStatusCode> UpdateStatusAsync(string errandId, string status)
        {
            ChangeErrandStatusModel errandstatus = new ChangeErrandStatusModel { ErrandId = errandId, Status = status.ToString() };
            
            var uri = new Uri(string.Format($"{BaseUrl}/errands?", string.Empty));

            var json = JsonConvert.SerializeObject(errandstatus);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return HttpStatusCode.OK;
                //return RedirectToPage("ErrandDetails", new { elevatorId, errandId = Errand.Id.ToString() });
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public async Task<HttpStatusCode> UpdateErrandStatus(string errandId, ErrandStatus status)
        {
            var uri = new Uri(string.Format($"{BaseUrl}/errands?id={errandId}", string.Empty));

            var response = await _client.PutAsync(uri.ToString(), new StringContent("{'id':" + errandId + ",'status':" + status.ToString() + "}", Encoding.UTF8, "application/json"));

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
