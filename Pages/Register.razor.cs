// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Register
    {
        private AuthenticateModel _authenticateModel = new AuthenticateModel();
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private async void OpenServerBrowser()
        {
            var loggedInAs = await UserService.Register(_authenticateModel);
            if (loggedInAs == null) return;
            Console.WriteLine($"Logged in as: {loggedInAs}");
            NavigationManager.NavigateTo("/lobbyBrowser");
        }
    }
}