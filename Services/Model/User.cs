// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace UI.Services.Model
{
    public class User
    {
        public User() { }

        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string GetSalt() { return PasswordHash.Substring(0, 27) + '='; }

        public override string ToString() { return $"{{ Username: {Username} }}"; }
    }
}