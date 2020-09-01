using System;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace UI.Pages.LobbyBrowser
{
    public partial class LobbyBrowser
    {
        [Inject] private UserService UserService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IModalService Modal { get; set; }
        [Inject] private LobbyService LobbyService { get; set; }

        private void JoinLobby(int lobbyId)
        {
            NavigationManager.NavigateTo("/lobby/ " + lobbyId);
        }

        private async void CreateLobby()
        {
            var modal = Modal.Show<CreateLobbyModal>("Create Lobby");
            var result = await modal.Result;

            if (result.Cancelled) return;

            var lobbyDTO = await LobbyService.CreateLobby((CreateLobbyDTO) result.Data);
            NavigationManager.NavigateTo("/lobby/1"); // TODO navigate to lobby/lobbyId
        }
    }
}