using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services.Model;

namespace UI.Services
{
    public class LobbyService : Service
    {
        private const string Url = "lobby";

        public LobbyService(AuthenticationStateProvider authenticationStateProvider, HttpClient http,
            NavigationManager navigationManager)
            : base(authenticationStateProvider, http, navigationManager)
        {
        }

        public async Task<LobbyDTO> CreateLobby(CreateLobbyDTO lobby)
        {
            if (!await CheckAuthorized()) return null;
            var response = await Http.PutAsync(Url, JsonContent.Create(lobby));
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<LobbyDTO>();
            Console.WriteLine("Failed creating a new Lobby"); // TODO add error handling
            return null;
        }
    }
}