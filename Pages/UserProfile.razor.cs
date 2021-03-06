﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;
using UI.Services.Model;

namespace UI.Pages
{
    public partial class UserProfile
    {
        private User _user = new User();
        [Parameter] public string Username { get; set; }
        [Inject] private UserService UserService { get; set; }

        protected override async Task OnInitializedAsync() { _user = await UserService.GetUser(Username); }
    }
}