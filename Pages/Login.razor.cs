﻿// ReSharper disable FieldCanBeMadeReadOnly.Local
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Console.WriteLine($"URI: {NavigationManager.Uri}");
        }

        private void CheckEnter(KeyboardEventArgs e)
        {
            if (e.Key.Equals("Enter")) OpenServerBrowser();
        }

        private async void OpenServerBrowser()
        {
            var loggedInAs = await UserService.Login(_userName, SecurityService.HashPassword(_password));
            if (loggedInAs == null) return;
            Console.WriteLine($"Logged in: {loggedInAs}");
            NavigationManager.NavigateTo("/serverBrowser");
        }
    }
}