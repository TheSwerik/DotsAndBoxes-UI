using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UI.Services;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            
            builder.Services.AddSingleton<UserService>();
                    // app.MapWhen(
                    //     context => context.Request.Path.StartsWithSegments("/api"),
                    //     builder => builder.RunProxy(new ProxyOptions
                    //                                 {
                    //                                     Scheme = "https",
                    //                                     Host = "example.com",
                    //                                     Port = "80",
                    //                                 })
                    // );

            await builder.Build().RunAsync();
        }
    }
}