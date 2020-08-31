// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services;
using UI.Services.Model;
using UI.Util;

namespace UI.Pages
{
    public partial class Register
    {
        private const string LobbyBrowserUrl = "/lobbyBrowser";
        [Inject] private AuthenticationService AuthenticationService { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        public AuthenticateModel AuthenticateModel { get; set; } = new AuthenticateModel();
        [Required] [PasswordValidator("AuthenticateModel")] public string ConfirmPassword { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity.IsAuthenticated) NavigationManager.NavigateTo(LobbyBrowserUrl);
        }

        private async void OpenServerBrowser()
        {
            var user = await AuthenticationService.Register(AuthenticateModel);
            if (user == null) return;
            Console.WriteLine($"Logged in as: {user.Username}");
            NavigationManager.NavigateTo(LobbyBrowserUrl);
        }
    }
}