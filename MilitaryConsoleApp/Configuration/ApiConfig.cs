
namespace MilitaryConsoleApp.Configuration
{
    public class ApiConfig
    {
        public string ApiUrl { get; set; } = "https://api.allegro.pl.allegrosandbox.pl";
        public string Token { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string TokenEndpoint { get; set; } = "https://allegro.pl/auth/oauth/token";
    }
}
