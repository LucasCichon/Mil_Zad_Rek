
namespace MilitaryConsoleApp.Services
{
    public interface IBillingService
    {
        public Task ProcessOrdersBillingEntriesAsync();
        public Task ProcessOffersBillingEntriesAsync();
    }
}
