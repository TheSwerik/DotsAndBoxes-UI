using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UI.Services.Model;

namespace UI.Services
{
    public class UserService
    {
        private const string Url = "user";
        private const string LoginUrl = "user/login";
        private readonly HttpClient _http;
        public User CurrentUser;
        public UserService(HttpClient http) { _http = http; }

        public async Task<User> CreateUser(User user)
        {
            return CurrentUser = await (await _http.PostAsync(Url, JsonContent.Create(user)))
                                       .Content
                                       .ReadFromJsonAsync<User>();
        }

        public async Task<User> Login(string username, string password)
        {
            var encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
            var response = await _http.GetAsync(LoginUrl);
            if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();
            else
            {
                Console.WriteLine("WRONG USERNAME OR PASSWORD");
                return null;
            }
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