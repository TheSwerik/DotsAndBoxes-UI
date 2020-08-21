using System;
using Microsoft.AspNetCore.Components;

namespace UI.Pages
{
    public partial class Game
    {
        [Parameter] public int GameId { get; set; }

        protected override void OnInitialized() { Console.WriteLine($"Browser: {GameId}"); }
    }
}