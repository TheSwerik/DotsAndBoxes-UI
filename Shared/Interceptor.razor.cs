using System;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;

namespace UI.Shared
{
    public partial class Interceptor
    {
        [Inject] private HttpClientInterceptor HttpClientInterceptor { get; set; }
        protected override void OnInitialized() { HttpClientInterceptor.BeforeSend += Interceptor_BeforeSend; }

        private void Interceptor_BeforeSend(object sender, HttpClientInterceptorEventArgs e)
        {
            Console.WriteLine($"Intercepted {e.Response}");
            if (e.Response == null) return;
            Console.WriteLine($"Intercepted {e.Response.StatusCode}");
        }
    }
}