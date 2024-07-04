
namespace MilitaryConsoleApp.Services
{
    public interface IAuthService
    {
        Task<string> GetAccessTokenAsync();
    }
}
