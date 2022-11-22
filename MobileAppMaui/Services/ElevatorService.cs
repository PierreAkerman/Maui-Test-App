﻿using Newtonsoft.Json;
using System.Diagnostics;
using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public class ElevatorService : IElevatorService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;
        public List<ElevatorDetailsModel> Items { get; set; }
        public ElevatorDetailsModel Item { get; private set; }

        public ElevatorService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<ElevatorDetailsModel>> GetAllElevatorsAsync()
        {
            Items = new List<ElevatorDetailsModel>();

            var uri = new Uri(string.Format($"{BaseUrl}/elevator/all/detailed?", string.Empty));
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

            var uri = new Uri(string.Format($"{BaseUrl}/elevator?id={id}", string.Empty));
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
