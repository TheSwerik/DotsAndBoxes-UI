using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services.Model;

namespace UI.Services
{
    public class UserService
    {
        #region Attributes

        private const string Url = "user";
        private const string LoginUrl = "user/login";
        private const string RegisterUrl = "user/register";
        private readonly HttpClient _http;
        public User CurrentUser;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient http, AuthenticationStateProvider authStateProvider,
                           ILocalStorageService localStorage)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

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
            if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine($"USER WITH USERNAME {username} NOT FOUND!");
            return null;
        }

        #region Authentication

        // public async Task<User> Login(AuthenticateModel user)
        // {
        //     SetAuthorizationHeader(user);
        //     var request = new HttpRequestMessage();
        //     Console.WriteLine(string.Join("\n", request.Properties.Keys));
        //     // await _http.SendAsync(request);
        //     var response = await _http.GetAsync(LoginUrl);
        //     if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();
        //
        //     Console.WriteLine("WRONG USERNAME OR PASSWORD");
        //     return null;
        // }

        public async Task<User> Register(AuthenticateModel user)
        {
            SetAuthorizationHeader(user);
            var response = await _http.PostAsync(RegisterUrl, JsonContent.Create(user));
            if (response.IsSuccessStatusCode) return CurrentUser = await response.Content.ReadFromJsonAsync<User>();

            Console.WriteLine(await response.Content.ReadFromJsonAsync<ResponseMessage>());
            return null;
        }

        private void SetAuthorizationHeader(AuthenticateModel user)
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                                         .GetBytes(user.Username + ":" + user.Password));
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
            //TODO save cookie
        }

        public async Task<Model.AuthResponseDto> Login(Model.AuthResponseDto userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _http.PostAsync(LoginUrl, bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result =
                JsonSerializer.Deserialize<Model.AuthResponseDto>(authContent,
                                                                  new JsonSerializerOptions
                                                                  {PropertyNameCaseInsensitive = true});
            if (!authResult.IsSuccessStatusCode) return result;
            await _localStorage.SetItemAsync("authToken", result.Token);
            ((AuthStateProvider) _authStateProvider).NotifyUserAuthentication(userForAuthentication.Username);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new Model.AuthResponseDto {IsAuthSuccessful = true};
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider) _authStateProvider).NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }

        #endregion

        #endregion
    }

    public class AuthResponseDto
    {
    }
}