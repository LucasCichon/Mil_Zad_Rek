using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Configuration;

namespace MilitaryConsoleApp.Services
{
    public class SandboxAuthService : IAuthService
    {
        private readonly ApiConfig _apiConfig;

        public SandboxAuthService(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }
        public Task<string> GetAccessTokenAsync()
        {
            string token = File.ReadAllText("token.txt").Trim();
            _apiConfig.Token = token;
            return Task.FromResult(token);
        }
    }
}
