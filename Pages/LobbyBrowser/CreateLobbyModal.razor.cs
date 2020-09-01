using System;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using UI.Services.Model;

namespace UI.Pages.LobbyBrowser
{
    public partial class CreateLobbyModal
    {
        [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }

        private CreateLobbyDTO LobbyDto = new CreateLobbyDTO();

        private void CreateLobby()
        {
            BlazoredModal.Close(ModalResult.Ok(LobbyDto));
        }

        private void Cancel()
        {
            BlazoredModal.Close(ModalResult.Cancel());
        }
    }
}