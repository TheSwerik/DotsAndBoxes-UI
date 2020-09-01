// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;

namespace UI.Pages
{
    public partial class Logout
    {
        [Inject] private AuthenticationService AuthenticationService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("/login");
        }
    }
}