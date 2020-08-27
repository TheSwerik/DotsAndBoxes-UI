using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UI.Services.Model;

namespace UI.Services
{
    public class UserService
    {
        private const string Url = "user";
        private const string AuthenticateUrl = "user/authenticate";
        private readonly HttpClient _http;
        public User CurrentUser;
        public UserService(HttpClient http) { _http = http; }

        public async Task<User> CreateUser(User user)
        {
            return CurrentUser = await (await _http.PostAsync(Url, JsonContent.Create(user)))
                                       .Content
                                       .ReadFromJsonAsync<User>();
        }

        public async Task<User> Authenticate(AuthenticateModel user)
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                                         .GetBytes(user.Username + ":" + user.Password));
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
            // var response = await _http.GetAsync(AuthenticateUrl);
            var response = await _http.PostAsync(AuthenticateUrl, JsonContent.Create(user));
            if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine("WRONG USERNAME OR PASSWORD");
            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await (await _http.GetAsync(Url))
                         .Content
                         .ReadFromJsonAsync<IEnumerable<User>>();
        }

        public async Task<User> GetUser(string username)
        {
            var response = await _http.GetAsync(Url + $"/{username}");

            if (response.IsSuccessStatusCode)
                Console.WriteLine("Content: " + await response.Content.ReadAsStringAsync());
            // if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine($"USER WITH USERNAME {username} NOT FOUND!");
            return null;
        }
    }
}