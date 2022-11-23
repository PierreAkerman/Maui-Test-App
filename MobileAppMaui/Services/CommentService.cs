﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public class CommentService : ICommentService
    {
        private const string BaseUrl = "https://grupp3azurefunctions.azurewebsites.net/api";

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public ErrandCommentModel Comment;

        public CommentService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task SaveCommentAsync(ErrandCommentModel comment) // Inte klar/testat!
        {
            var uri = new Uri(string.Format($"{BaseUrl}comment/create", string.Empty));
            try
            {
                var json = JsonSerializer.Serialize(comment, _serializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
