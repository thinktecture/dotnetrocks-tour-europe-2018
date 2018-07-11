using BlazorClient.Services;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddScoped<MessageService>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
