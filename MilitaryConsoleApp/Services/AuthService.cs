using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.ErrorHandling;
using MilitaryConsoleApp.Models;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Text;


namespace MilitaryConsoleApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApiConfig _apiConfig;

        public AuthService(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var authorizationCode = await getAuthorizationCode();

            var client = new RestClient("https://allegro.pl/auth/oauth/token");
            var request = new RestRequest("https://allegro.pl/auth/oauth/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", authorizationCode);
            request.AddParameter("redirect_uri", _apiConfig.RedirectUri);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_apiConfig.ClientId}:{_apiConfig.ClientSecret}")));

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                _apiConfig.Token = tokenResponse.AccessToken;
                return tokenResponse.AccessToken;
            }
            else
            {
                Console.WriteLine("Failed to obtain access token.");
                Console.WriteLine(response.Content);
                return null;
            }
        }


        private async Task<string> getAuthorizationCode()
        {
            string authorizationUrl = $"https://allegro.pl/auth/oauth/authorize?response_type=code&client_id={_apiConfig.ClientId}&redirect_uri={_apiConfig.RedirectUri}";
            Process.Start(new ProcessStartInfo(authorizationUrl) { UseShellExecute = true });
            Console.WriteLine("Please authorize the application in your browser...");

            // Start a simple HTTP server to handle the callback
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/callback/");
            listener.Start();
            Console.WriteLine("Listening for authorization code...");

            HttpListenerContext context = listener.GetContext();
            string authorizationCode = context.Request.QueryString["code"];
            Console.WriteLine($"Authorization code received: {authorizationCode}");

            listener.Stop();

            return authorizationCode;
        }
    }
}
