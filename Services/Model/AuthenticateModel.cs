using System.ComponentModel.DataAnnotations;
using UI.Util;

namespace UI.Services.Model
{
    // ReSharper disable once InconsistentNaming
    public class AuthenticateModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] [PasswordValidator("Password")] public string ConfirmPassword { get; set; }
        public override string ToString() { return $"{{ Username: {Username}  | Password: {Password} }}"; }
    }
}