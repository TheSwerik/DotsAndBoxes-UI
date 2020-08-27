// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace UI.Services.Model
{
    public class User
    {
        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string GetSalt() { return Password.Substring(0, 27) + '='; }

        public override string ToString() { return $"{{ Username: {Username} }}"; }
    }
}