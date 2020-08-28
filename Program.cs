using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UI.Services;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<CookieService>();
            builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("https://localhost:5003/api/")});

            await builder.Build().RunAsync();
        }
    }
}