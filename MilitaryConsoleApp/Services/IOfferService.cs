
namespace MilitaryConsoleApp.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<Models.Offer>> GetOffersAsync();
    }
}
