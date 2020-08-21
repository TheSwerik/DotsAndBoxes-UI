using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Services;

namespace UI.Pages.Login
{
    public partial class Login
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
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