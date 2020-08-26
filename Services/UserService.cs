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
        public User CurrentUser;
        public UserService(HttpClient http) { _http = http; }

        public async Task<User> CreateUser(string username)
        {
            return CurrentUser = await (await _http.PostAsync(Url, JsonContent.Create(username)))
                                       .Content
                                       .ReadFromJsonAsync<User>();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await (await _http.GetAsync(Url))
                         .Content
                         .ReadFromJsonAsync<IEnumerable<User>>();
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await (await _http.GetAsync(Url + $"/{userId}"))
                         .Content
                         .ReadFromJsonAsync<User>();
        }
    }
}