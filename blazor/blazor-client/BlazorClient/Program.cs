using BlazorClient.Services;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorClient
{
    public class Program
    {
        public static IServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            ServiceProvider = new BrowserServiceProvider(services =>
            {
                services.AddScoped<MessageService>();
            });

            new BrowserRenderer(ServiceProvider).AddComponent<App>("app");
        }
    }
}
