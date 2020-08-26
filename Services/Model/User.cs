// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace UI.Services.Model
{
    public class User
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public User() { Id = Guid.Empty; }

        public User(string username, string passwordHash) : base()
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        public string Salt() { return PasswordHash.Substring(0, 27); }

        public override string ToString() { return $"{{ ID: {Id} | Username: {Username} }}"; }
    }
}