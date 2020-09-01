using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Util;

namespace UI.Services
{
    public abstract class Service
    {
        protected readonly AuthStateProvider AuthenticationStateProvider;
        protected readonly HttpClient Http;
        protected readonly NavigationManager NavigationManager;

        protected Service(AuthenticationStateProvider authenticationStateProvider, HttpClient http,
                          NavigationManager navigationManager)
        {
            AuthenticationStateProvider = (AuthStateProvider) authenticationStateProvider;
            Http = http;
            NavigationManager = navigationManager;
        }

        protected async Task<bool> CheckAuthorized()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (!state.User.Identity.IsAuthenticated) NavigationManager.NavigateTo("/logout");
            return state.User.Identity.IsAuthenticated;
        }
    }
}