// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace UI.Services.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public override string ToString() { return $"{{ Username: {Username} }}"; }
    }
}