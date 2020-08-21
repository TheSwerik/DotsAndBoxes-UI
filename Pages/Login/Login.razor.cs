using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Entities;
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

        private void OpenServerBrowser()
        {
            UserService.CreateUser(_userName).ConfigureAwait(false);
            UserService.GetAllUsers().ConfigureAwait(false);
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}