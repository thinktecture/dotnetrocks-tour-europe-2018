using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
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
            });

            new BrowserRenderer(ServiceProvider).AddComponent<App>("app");
        }
    }
}
