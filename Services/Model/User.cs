﻿// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.ComponentModel.DataAnnotations;

namespace UI.Services.Model
{
    // ReSharper disable once InconsistentNaming
    public class User
    {
        public User() { }

        public User(string username) { Username = username; }

        [Required] public string Username { get; set; }
        public string Token { get; set; }

        public override string ToString() { return $"{{ Username: {Username} }}"; }
    }
}