using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace UI.Services
{
    public class TestAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claims = new List<Claim>
                         {
                             new Claim(ClaimTypes.Name, "Erik"),
                             new Claim(ClaimTypes.Role, "User")
                         };
            var anonymous = new ClaimsIdentity(claims, "testAuthType");
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}