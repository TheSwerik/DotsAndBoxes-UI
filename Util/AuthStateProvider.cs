using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace UI.Util
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly AuthenticationState _anonymous;
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrWhiteSpace(token)) return _anonymous;

            var parsedToken = JwtParser.ParseClaimsFromJwt(token).ToList();
            var date = parsedToken.FirstOrDefault(c => c.Type.Equals("exp", StringComparison.InvariantCulture));
            if (date == null || double.Parse(date.Value) < NowUnix()) return _anonymous;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(CreateClaimsPrinciple(parsedToken));
        }

        public void NotifyUserAuthentication(string username)
        {
            var authenticatedUser = CreateClaimsPrinciple(new[] {new Claim(ClaimTypes.Name, username)});
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
        }

        public void NotifyUserLogout() { NotifyAuthenticationStateChanged(Task.FromResult(_anonymous)); }

        private ClaimsPrincipal CreateClaimsPrinciple(IEnumerable<Claim> claims)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType"));
        }

        private static double NowUnix() { return (DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds; }
    }
}