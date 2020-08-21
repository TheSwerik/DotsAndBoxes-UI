using System;

namespace UI.Pages
{
    public partial class ServerBrowser
    {
        private void Refresh() { Console.WriteLine(UserService.CurrentUser); }
    }
}