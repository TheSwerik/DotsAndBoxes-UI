using System;
using Microsoft.AspNetCore.Components;

namespace UI.Shared
{
    public partial class Navbar
    {
        private string _user = "swerik";
        [Inject] public NavigationManager MyNavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Console.WriteLine(MyNavigationManager.Uri);
        }
    }
}