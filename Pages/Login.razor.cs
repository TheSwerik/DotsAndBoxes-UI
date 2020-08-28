// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Login
    {
        private AuthenticateModel _authenticateModel = new AuthenticateModel();
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override void OnInitialized()
        {
            if (NavigationManager.Uri == NavigationManager.BaseUri) NavigationManager.NavigateTo("/login");
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            Console.WriteLine($"Identity: {state.User.Identity.Name}");
        }

        private async void OpenServerBrowser()
        {
            Console.WriteLine($"Logged in as: {await UserService.Login(_authenticateModel)}");
            // NavigationManager.NavigateTo("/lobbyBrowser", true);
            NavigationManager.NavigateTo("/lobbyBrowser");
        }
    }
}