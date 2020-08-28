using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UI.Services.Model;

namespace UI.Services
{
    public class UserService
    {
        #region Attributes

        private const string Url = "user";
        private readonly HttpClient _http;

        public UserService(HttpClient http) { _http = http; }

        #endregion

        #region Methods

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await (await _http.GetAsync(Url))
                         .Content
                         .ReadFromJsonAsync<IEnumerable<User>>();
        }

        public async Task<User> GetUser(string username)
        {
            var response = await _http.GetAsync(Url + $"/{username}");
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine($"USER WITH USERNAME {username} NOT FOUND!");
            return null;
        }

        #endregion
    }
}