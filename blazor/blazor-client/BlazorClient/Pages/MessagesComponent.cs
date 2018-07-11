using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorClient.Models;
using BlazorClient.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorClient.Pages
{
    public class MessagesComponent : BlazorComponent
    {
        [Inject]
        private MessageService _messageService { get; set; }

        protected IEnumerable<ChatMessage> Messages { get; private set; }

        protected override async Task OnInitAsync()
        {
            Messages = await _messageService.GetMessages();
        }
    }
}
