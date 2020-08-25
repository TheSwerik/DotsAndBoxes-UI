// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Services;

namespace UI.Pages
{
    public partial class Login
    {
        private string _userName = "";
        [Inject] private UserService UserService { get; set; }

        private void CheckEnter(KeyboardEventArgs e)
        {
            if (e.Key.Equals("Enter")) OpenServerBrowser();
        }

        private async void OpenServerBrowser()
        {
            Console.WriteLine("CREATED: " + await UserService.CreateUser(_userName));
            Console.WriteLine("GOT: " + string.Join("\t", await UserService.GetAllUsers()));
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}