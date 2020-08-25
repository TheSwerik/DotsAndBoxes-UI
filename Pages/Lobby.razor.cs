using Microsoft.AspNetCore.Components;

namespace UI.Pages
{
    public partial class Lobby
    {
        [Parameter] public int LobbyId { get; set; }

        private void StartGame() { NavigationManager.NavigateTo($"/game/{LobbyId}"); }
    }
}