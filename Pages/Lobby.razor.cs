using Microsoft.AspNetCore.Components;

namespace UI.Pages
{
    public partial class Lobby
    {
        [Parameter] public int LobbyId { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private void StartGame() { NavigationManager.NavigateTo($"/game/{LobbyId}"); }
    }
}