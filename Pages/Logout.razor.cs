// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Logout
    {
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            UserService.CurrentUser = null;
            NavigationManager.NavigateTo("/login");
        }
    }
}