using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Services
{
    public class CookieService
    {
        private const string CookieString = "";
        [Inject] private JSRuntime JsRuntime { get; set; }

        public void CreateCookie(string name, string value, int days)
        {
            JsRuntime.InvokeVoidAsync("cookies.CreateCookie", name, value, days);
        }

        public async Task<string> ReadCookie(string name)
        {
            return await JsRuntime.InvokeAsync<string>("cookies.ReadCookie");
        }

        public async Task<string> ReadCookies() { return await JsRuntime.InvokeAsync<string>("cookies.ReadCookie"); }

        public void DeleteCookie(string name) { JsRuntime.InvokeVoidAsync("cookies.DeleteCookie", name); }
    }
}