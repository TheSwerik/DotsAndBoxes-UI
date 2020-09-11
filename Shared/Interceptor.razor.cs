using System.Net;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;

namespace UI.Shared
{
    public partial class Interceptor
    {
        [Inject] private HttpClientInterceptor HttpClientInterceptor { get; set; }
        [Inject] private IToastService ToastService { get; set; }

        public void Dispose() { HttpClientInterceptor.AfterSend -= Interceptor_AfterSend; }

        protected override void OnInitialized() { HttpClientInterceptor.AfterSend += Interceptor_AfterSend; }

        private async void Interceptor_AfterSend(object sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response == null || e.Response.IsSuccessStatusCode) return;

            var capturedContent = await e.GetCapturedContentAsync();
            var responseString = await capturedContent.ReadAsStringAsync();
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (e.Response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.Unauthorized:
                    ToastService.ShowError(responseString, "Error");
                    break;
            }
        }
    }
}