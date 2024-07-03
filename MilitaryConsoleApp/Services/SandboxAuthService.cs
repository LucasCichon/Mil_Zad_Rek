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
