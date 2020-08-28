using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class LobbyBrowser
    {
        private IEnumerable<User> _users = new List<User>();
        [Inject] private UserService UserService { get; set; }

        protected override async Task OnInitializedAsync() { _users = await UserService.GetAllUsers(); }
    }
}