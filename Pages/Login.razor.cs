// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class Login
    {
        private string _password = "";
        private string _userName = "";
        [Inject] private UserService UserService { get; set; }
        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private void CheckEnter(KeyboardEventArgs e)
        {
            if (e.Key.Equals("Enter")) OpenServerBrowser();
        }

        private async void OpenServerBrowser()
        {
            var loggedInAs = await UserService.GetUser(_userName);
            if (loggedInAs == null)
            {
                Console.WriteLine("The User does not exist.");
                return;
            }

            var user = new AuthenticateModel
                       {
                           Username = _userName,
                           Password = SecurityService.HashPassword(_password, loggedInAs.GetSalt())
                       };
            Console.WriteLine(await UserService.Authenticate(user));
            if (loggedInAs == null)
            {
                Console.WriteLine("Wrong Password!");
                return;
            }

            // Console.WriteLine($"Logged in: {loggedInAs}");
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}