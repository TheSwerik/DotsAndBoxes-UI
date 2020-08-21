using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Entities;

namespace UI.Services
{
    public class UserService
    {
        private const string Url = "user";
        private readonly HttpClient _http;
        public User CurrentUser;
        public UserService(HttpClient http) { _http = http; }

        public async Task<User> CreateUser(string username)
        {
            var response = await _http.PostAsync(Url, JsonContent.Create(username));
            CurrentUser = await response.Content.ReadFromJsonAsync<User>();
            Console.WriteLine(CurrentUser);
            return CurrentUser;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            Console.WriteLine(await _http.GetAsync(Url));
            // return await _http.GetFromJsonAsync<User[]>(Url);
            return JsonSerializer.Deserialize<User[]>(await _http.GetAsync(Url).Result.Content.ReadAsStringAsync());
        }
    }
}