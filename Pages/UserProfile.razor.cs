using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class UserProfile
    {
        private User _user;
        [Parameter] public Guid UserId { get; set; }
        [Inject] private UserService UserService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _user = await UserService.GetUser(UserId);
        }
    }
}