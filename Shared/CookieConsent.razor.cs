using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;

namespace UI.Shared
{
    public partial class CookieConsent
    {
        private const string Consent = "Consent";
        private bool _hasGivenConsent;
        [Inject] private CookieService CookieService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _hasGivenConsent = await CookieService.GetCookieValue<bool>(Consent);
        }

        private void AcceptMessage() { CookieService.CreateCookie(Consent, true.ToString(), 365); }
    }
}