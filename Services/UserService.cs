using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Entities;

namespace UI.Services
{
    public class UserService 
    {
        public User CurrentUser;
        public UserService(HttpClient http) { Http = http; }
        [Inject] private HttpClient Http { get; set; }
        private const string Url = "https://localhost:5003/api/";

        public async Task<User> CreateUser(string username)
        {
            var response = await Http.PostAsync(Url + "user", new StringContent("abc"));
            return CurrentUser;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await Http.GetAsync(Url + "user");
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return null;
        }
    }
}