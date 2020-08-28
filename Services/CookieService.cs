using System;
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

        public async Task<string> GetCookieValue(string name)
        {
            var cookie = await ReadCookie(name);
            if (cookie == null) return null;
            return cookie.Substring(cookie.IndexOf('=') + 1);
        }

        public async Task<T> GetCookieValue<T>(string name)
        {
            var cookieValue = await GetCookieValue(name);
            if (string.IsNullOrWhiteSpace(cookieValue)) return default;
            return (T) Convert.ChangeType(cookieValue, typeof(T));
        }

        public async Task<string> ReadCookie(string name)
        {
            return await JsRuntime.InvokeAsync<string>("cookies.ReadCookie");
        }

        public async Task<string> ReadCookies() { return await JsRuntime.InvokeAsync<string>("cookies.ReadCookie"); }

        public void DeleteCookie(string name) { JsRuntime.InvokeVoidAsync("cookies.DeleteCookie", name); }
    }
}