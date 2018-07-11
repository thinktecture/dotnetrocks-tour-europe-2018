﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorDemo.Pages;
using Microsoft.AspNetCore.Blazor;

namespace BlazorDemo.Services
{
    public class MessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ChatMessage>> GetMessages()
        {
            var data = await _httpClient.GetJsonAsync<ChatMessage[]>(
                "https://xtreme-serverless-functions.azurewebsites.net/api/messages/list");

            return data.ToList();
        }
    }
}