using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services.Model;

namespace UI.Services
{
    public class LobbyService : Service
    {
        public LobbyService(AuthenticationStateProvider authenticationStateProvider, HttpClient http,
            NavigationManager navigationManager)
            : base(authenticationStateProvider, http, navigationManager)
        {
        }

        public async Task<LobbyDTO> CreateLobby(CreateLobbyDTO dto)
        {
            
        }
    }
}