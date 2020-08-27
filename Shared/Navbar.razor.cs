using System;
using Microsoft.AspNetCore.Components;
using UI.Services;

namespace UI.Shared
{
    public partial class Navbar
    {
        private Guid _user = new Guid();
        [Inject] private NavigationManager MyNavigationManager { get; set; }
        [Inject] private UserService UserService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Console.WriteLine(MyNavigationManager.Uri);
        }

        private bool isHighscore()
        {
            return MyNavigationManager.Uri.Equals("highscore", StringComparison.InvariantCultureIgnoreCase);
        }

        private bool isLobby()
        {
            return MyNavigationManager.Uri.Contains("lobby", StringComparison.InvariantCultureIgnoreCase);
        }

        private bool isLogin()
        {
            return MyNavigationManager.Uri.Equals("login", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}