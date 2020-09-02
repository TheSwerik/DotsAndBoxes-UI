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
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (e.Response?.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    ToastService.ShowError("The Username already exists.", "Error");
                    break;
                case HttpStatusCode.NotFound:
                    ToastService.ShowError("The Username doesn't exist.", "Error");
                    break;
                case HttpStatusCode.Unauthorized:
                    ToastService.ShowError("Wrong Username or Password.", "Error");
                    break;
            }
        }
    }
}