using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorClient.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace BlazorClient.Services
{
    public class MessageService
    {
        private readonly HttpClient _httpClient;

        public static event EventHandler NewMessagesAvailable;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [JSInvokable]
        public static void NotifyNewMessagesAvailable()
        {
            NewMessagesAvailable?.Invoke(typeof(MessageService), EventArgs.Empty);
        }

        public async Task<ChatMessage[]> GetMessagesAsync()
        {
            return await _httpClient.GetJsonAsync<ChatMessage[]>(
                "https://xtreme-serverless-functions-live.azurewebsites.net/api/messages");
        }
    }
}
