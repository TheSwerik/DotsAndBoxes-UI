using System;
using Microsoft.AspNetCore.Components;
using UI.Services;

namespace UI.Shared
{
    public partial class CookieConsent
    {
        [Inject] private CookieService CookieService { get; set; }
        protected override async void OnInitialized() { Console.WriteLine(await CookieService.ReadCookies()); }
        private void AcceptMessage() { CookieService.CreateCookie("Consent", "true", 365); }
    }
}