using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace UI.Services
{
    public class CookieService
    {
        private const string CookieString = "";
        public CookieService(IJSRuntime jsRuntime) { JsRuntime = jsRuntime; }
        private IJSRuntime JsRuntime { get; }

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