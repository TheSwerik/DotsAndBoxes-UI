using System;

namespace UI.Pages
{
    public partial class LobbyBrowser
    {
        private void Refresh() { Console.WriteLine(UserService.CurrentUser); }
    }
}