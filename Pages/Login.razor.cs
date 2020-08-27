// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Login
    {
        private AuthenticateModel _authenticateModel = new AuthenticateModel();
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private async void OpenServerBrowser()
        {
            Console.WriteLine($"Logged in as: {await UserService.Authenticate(_authenticateModel)}");
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}