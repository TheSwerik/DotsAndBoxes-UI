using System;

namespace UI.Pages
{
    public partial class LobbyBrowser
    {
        private void Refresh()
        {
            Console.WriteLine(UserService.CurrentUser);
        }

        private async void JoinLobby(int lobby)
        {
            NavigationManager.NavigateTo("/lobby/ " + lobby);
        }
    }
}