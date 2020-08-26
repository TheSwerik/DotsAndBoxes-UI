using System;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Util;

namespace UI.Shared
{
    public partial class Navbar
    {
        private const string RegisterUri = "/register";
        private const string LoginUri = "/login";
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private UserService UserService { get; set; }

        private bool IsHighscore() { return Comparer.EqualsUri(NavigationManager, "highscore"); }

        private bool IsLobby() { return Comparer.ContainsUri(NavigationManager, "lobby"); }

        private bool IsLogin() { return Comparer.EqualsUri(NavigationManager, "login", ""); }

        private void NavigateTo(string uri) { NavigationManager.NavigateTo(uri, true); }
    }
}