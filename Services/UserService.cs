using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services.Model;

namespace UI.Services
{
    public class UserService : Service
    {
        private const string Url = "user";

        public UserService(AuthenticationStateProvider authenticationStateProvider, HttpClient http,
                           NavigationManager navigationManager)
            : base(authenticationStateProvider, http, navigationManager)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            if (!await CheckAuthorized()) return null;
            var response = await Http.GetAsync(Url);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IEnumerable<User>>();

            Console.WriteLine("Get All Users had an Error.");
            return null;
        }

        public async Task<User> GetUser(string username)
        {
            if (!await CheckAuthorized()) return null;
            var response = await Http.GetAsync(Url + $"/{username}");
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<User>();
            if (response.StatusCode == HttpStatusCode.NotFound)
                Console.WriteLine($"USER WITH USERNAME {username} NOT FOUND!");
            return null;
        }
    }
}