// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace UI.Services.Model
{
    public struct User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public override string ToString() { return $"{{ ID: {Id} | Username: {Username} }}"; }
    }
}