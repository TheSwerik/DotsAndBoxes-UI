// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Register
    {
        private string _password = "";
        private string _userName = "";
        [Inject] private UserService UserService { get; set; }

        private void CheckEnter(KeyboardEventArgs e)
        {
            if (e.Key.Equals("Enter")) OpenServerBrowser();
        }

        private async void OpenServerBrowser()
        {
            var newUser = new User(_userName, SecurityService.HashPassword(_password));
            Console.WriteLine("CREATED: " + await UserService.CreateUser(newUser));
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}