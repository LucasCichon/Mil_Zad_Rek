using MilitaryConsoleApp.Repositories;

namespace MilitaryConsoleApp.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Models.Offer>> GetOffersAsync()
        {
            return await _offerRepository.GetOffersAsync();
        }
    }
}
