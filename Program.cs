using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UI.Services;
using UI.Util;
using Blazored.Modal;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("https://localhost:5003/api/")});
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddBlazoredModal();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}