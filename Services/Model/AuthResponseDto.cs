namespace UI.Services.Model
{
    public class AuthResponseDto
    {
        public string Username { get; set; }
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}