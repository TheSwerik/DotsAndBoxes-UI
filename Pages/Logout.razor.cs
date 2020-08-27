// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using Microsoft.AspNetCore.Components;
using UI.Services;

namespace UI.Pages
{
    public partial class Logout
    {
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            //TODO delete cookie
            UserService.CurrentUser = null;
            NavigationManager.NavigateTo("/login");
        }
    }
}