// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace UI.Services.Model
{
    public struct User
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public User(string username, string passwordHash)
        {
            Id = Guid.Empty;
            Username = username;
            PasswordHash = passwordHash;
        }

        public string Salt() { return PasswordHash.Substring(0, 27); }

        public override string ToString() { return $"{{ ID: {Id} | Username: {Username} }}"; }
    }
}