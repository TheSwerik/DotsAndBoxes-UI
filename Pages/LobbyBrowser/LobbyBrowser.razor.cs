using System;
using Blazored.Modal;

namespace UI.Pages.LobbyBrowser
{
    public partial class LobbyBrowser
    {
        private void JoinLobby(int lobbyId)
        {
            NavigationManager.NavigateTo("/lobby/ " + lobbyId);
        }

        private async void CreateLobby()
        {
            var modal = Modal.Show<CreateLobbyModal>("Create Lobby");
            var result = await modal.Result;

            if (result.Cancelled) return;

            // TODO createLobby using result.Data
            // var lobbyDTO = await LobbyService.CreateLobby(result.Data);
            NavigationManager.NavigateTo("/lobby/1"); // TODO navigate to lobby/lobbyId
        }
    }
}