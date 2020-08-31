using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Services.Model;

namespace UI.Services
{
    public class AuthenticationService : Service
    {
        #region Attributes

        private const string Url = "authentication";
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(AuthenticationStateProvider authenticationStateProvider, HttpClient http,
                                     NavigationManager navigationManager, ILocalStorageService localStorage)
            : base(authenticationStateProvider, http, navigationManager)
        {
            _localStorage = localStorage;
        }

        #endregion

        #region Methods

        public async Task<User> Register(AuthenticateModel model)
        {
            SetAuthorizationHeader(model);
            var response = await Http.PostAsync(Url, JsonContent.Create(model));
            if (response.IsSuccessStatusCode) return await SetToken(await response.Content.ReadFromJsonAsync<User>());

            Console.WriteLine(await response.Content.ReadFromJsonAsync<ResponseMessage>());
            return null;
        }

        public async Task<User> Login(AuthenticateModel model)
        {
            SetAuthorizationHeader(model);
            var response = await Http.GetAsync(Url);
            if (response.IsSuccessStatusCode) return await SetToken(await response.Content.ReadFromJsonAsync<User>());

            Console.WriteLine(await response.Content.ReadFromJsonAsync<ResponseMessage>());
            return null;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            AuthenticationStateProvider.NotifyUserLogout();
            Http.DefaultRequestHeaders.Authorization = null;
        }

        private void SetAuthorizationHeader(AuthenticateModel user)
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                                         .GetBytes(user.Username + ":" + user.Password));
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
        }

        private async Task<User> SetToken(User user)
        {
            await _localStorage.SetItemAsync("authToken", user.Token);
            AuthenticationStateProvider.NotifyUserAuthentication(user.Username);
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);
            return user;
        }

        #endregion
    }
}