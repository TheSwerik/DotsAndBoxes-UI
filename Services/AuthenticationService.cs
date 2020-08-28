using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using UI.Services.Model;

namespace UI.Services
{
    public class AuthenticationService
    {
        #region Attributes

        private const string Url = "authentication";
        private readonly HttpClient _http;
        private readonly AuthStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient http, AuthStateProvider authStateProvider,
                                     ILocalStorageService localStorage)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        #endregion

        #region Methods

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

        public async Task<User> Login(AuthenticateModel model)
        {
            SetAuthorizationHeader(model);
            var response = await _http.GetAsync(LoginUrl);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("WRONG USERNAME OR PASSWORD");
                return null;
            }

            var user = await response.Content.ReadFromJsonAsync<User>();
            await _localStorage.SetItemAsync("authToken", user.Token);
            _authStateProvider.NotifyUserAuthentication(user.Username);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);
            return new AuthResponseDto {IsAuthSuccessful = true};
        }

        public async Task<AuthResponseDto> Login(AuthenticateModel model)
        {
            var userForAuthentication = new AuthResponseDto {Username = model.Username};
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _http.PostAsync(LoginUrl, bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result =
                JsonSerializer.Deserialize<AuthResponseDto>(authContent,
                                                            new JsonSerializerOptions
                                                            {PropertyNameCaseInsensitive = true});
            if (!authResult.IsSuccessStatusCode) return result;
            await _localStorage.SetItemAsync("authToken", result.Token);
            _authStateProvider.NotifyUserAuthentication(userForAuthentication.Username);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDto {IsAuthSuccessful = true};
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _authStateProvider.NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }

        #endregion
    }
}