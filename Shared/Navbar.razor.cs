using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services;
using UI.Util;

namespace UI.Shared
{
    public partial class Navbar
    {
        private const string RegisterUri = "/register";
        private const string LoginUri = "/login";
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private UserService UserService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (!authState.User.Identity.IsAuthenticated && !IsLogin() && !IsRegister())
                NavigationManager.NavigateTo(LoginUri);
        }

        private bool IsHighscore() { return Comparer.EqualsUri(NavigationManager, "highscore"); }

        private bool IsLobby() { return Comparer.ContainsUri(NavigationManager, "lobby"); }

        private bool IsLogin() { return Comparer.EqualsUri(NavigationManager, "login", ""); }
        private bool IsRegister() { return Comparer.EqualsUri(NavigationManager, "register", ""); }

        private void NavigateTo(string uri) { NavigationManager.NavigateTo(uri, true); }
    }
}