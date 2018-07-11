using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemo.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDemo.Pages
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
