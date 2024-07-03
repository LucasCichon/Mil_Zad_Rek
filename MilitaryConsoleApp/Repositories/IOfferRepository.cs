
namespace MilitaryConsoleApp.Repositories
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Models.Offer>> GetOffersAsync();
    }
}
