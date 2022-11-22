﻿using Newtonsoft.Json;
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
        public static readonly string baseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        public readonly HttpClient _client;
        public readonly JsonSerializerOptions _serializerOptions;

        public ErrandModel Item;

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

        public async Task<ErrandModel> GetOneErrandAsync(string id)
        {
            Item = new ErrandModel();

            var uri = new Uri(string.Format($"{baseUrl}/errand?id={id}", string.Empty));
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

            var uri = new Uri(string.Format($"{baseUrl}/technicianErrand?id={id}", string.Empty));

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
