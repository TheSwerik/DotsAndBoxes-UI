using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var response = await _http.PostAsync(Url, new StringContent("abc"));
            return CurrentUser;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await _http.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return null;
        }
    }
}