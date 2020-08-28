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
        private const string LobbyBrowserUrl = "/lobbyBrowser";
        private AuthenticateModel _authenticateModel = new AuthenticateModel();
        [Inject] private AuthenticationService AuthenticationService { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (NavigationManager.Uri == NavigationManager.BaseUri) NavigationManager.NavigateTo("/login");
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity.IsAuthenticated) NavigationManager.NavigateTo(LobbyBrowserUrl);
        }

        private async void OpenServerBrowser()
        {
            var user = await AuthenticationService.Login(_authenticateModel);
            if (user == null) return;
            Console.WriteLine($"Logged in as: {user.Username}");
            NavigationManager.NavigateTo(LobbyBrowserUrl);
        }
    }
}