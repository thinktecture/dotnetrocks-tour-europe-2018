﻿using System;
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
        
        public MessagesComponent()
        {
            MessageService.NewMessagesAvailable += MessageService_NewMessagesAvailable;
        }

        protected override async Task OnInitAsync()
        {
            await GetMessagesAsync();
        }

        private async void MessageService_NewMessagesAvailable(object sender, EventArgs e)
        {
            await GetMessagesAsync();
            StateHasChanged();
        }

        private async Task GetMessagesAsync()
        {
            Messages = await _messageService.GetMessagesAsync();
        }
    }
}
