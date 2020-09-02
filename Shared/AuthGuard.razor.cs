// ReSharper disable UnusedAutoPropertyAccessor.Local

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace UI.Shared
{
    public partial class AuthGuard
    {
        [Parameter] public string Url { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated) NavigationManager.NavigateTo(Url);
        }
    }
}