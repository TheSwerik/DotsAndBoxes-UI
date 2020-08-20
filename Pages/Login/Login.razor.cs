using System;
using Microsoft.AspNetCore.Components.Web;

namespace UI.Pages.Login
{
    public partial class Login
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private string _userName = "";

        private async void CallWeather()
        {
            Console.WriteLine(await Http.GetAsync("https://localhost:5003/api/weatherforecast"));
        }

        private void CheckEnter(KeyboardEventArgs e)
        {
            if (e.Key.Equals("Enter")) OpenServerBrowser();
        }

        private void OpenServerBrowser()
        {
            NavigationManager.NavigateTo("/serverBrowser");
            Console.WriteLine(_userName);
        }
    }
}