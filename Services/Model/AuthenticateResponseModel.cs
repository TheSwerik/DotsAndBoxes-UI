namespace UI.Services.Model
{
    // ReSharper disable once InconsistentNaming
    public class AuthenticateResponseModel
    {
        public bool IsAuthenticationSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}