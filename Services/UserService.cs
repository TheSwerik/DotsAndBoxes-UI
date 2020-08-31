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
        private const string Url = "user";
        private readonly HttpClient _http;

        public UserService(HttpClient http) { _http = http; }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await _http.GetAsync(Url);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<IEnumerable<User>>();

            Console.WriteLine("Get All Users had an Error.");
            return null;
        }

        public async Task<User> GetUser(string username)
        {
            var response = await _http.GetAsync(Url + $"/{username}");
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine($"USER WITH USERNAME {username} NOT FOUND!");
            return null;
        }
    }
}