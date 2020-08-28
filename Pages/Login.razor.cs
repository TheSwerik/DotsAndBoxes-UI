// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
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

        private async void OpenServerBrowser()
        {
            Console.WriteLine($"Logged in as: {await UserService.Login(_authenticateModel)}");
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            // Console.WriteLine($"Context: {state.User}");
            // NavigationManager.NavigateTo("/lobbyBrowser", true);
            NavigationManager.NavigateTo("/lobbyBrowser");
        }
    }
}