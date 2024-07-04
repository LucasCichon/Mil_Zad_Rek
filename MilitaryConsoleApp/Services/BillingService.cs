using MilitaryConsoleApp.Repositories;
using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Clients;
using Serilog;

namespace MilitaryConsoleApp.Services
{
    public class BillingService : IBillingService
    {
        private readonly IOrderService _orderService;
        private readonly IOfferService _offerService;
        private readonly IBillingRepository _billingRepository;
        private readonly IAllegroClient _allegroClient;

        public BillingService(IOrderService orderService, IOfferService offerService, IBillingRepository billingRepository, IAllegroClient allegroClient)
        {
            _orderService = orderService;
            _offerService = offerService;
            _billingRepository = billingRepository;
            _allegroClient = allegroClient;
        }

        public async Task ProcessOffersBillingEntriesAsync()
        {
            var offers = await _offerService.GetOffersAsync();
            Console.WriteLine($"There are {offers.Count()} offers to process");
            foreach (var offer in offers)
            {
                await SaveBillings(offer.OfferId.ToString(), GetBillingType.ByOfferId);
            }
        }

        public async Task ProcessOrdersBillingEntriesAsync()
        {
            var orders = await _orderService.GetOrdersAsync();
            Console.WriteLine($"There are {orders.Count()} orders to process");
            foreach (var order in orders)
            {
                await SaveBillings(order.OrderId.ToString(), GetBillingType.ByOrderId);
            }          
        }

        private async Task SaveBillings(string orderId, GetBillingType type)
        {            
            var billings = await _billingRepository.GetBillingsAsync(orderId, type);
            var billingEntries = await _allegroClient.GetBillingEntries(orderId, type);

            foreach(var billingEntry in billingEntries)
            {
                if(!billings.Any(b => b.BillingId == billingEntry.BillingId))
                {
                    await _billingRepository.SaveBillingEntryAsync(billingEntry);
                    Log.Information($"Billing ({billingEntry.BillingId}) saved.");
                }
                else
                {
                    Log.Information($"Billing ({billingEntry.BillingId}) already in Database.");
                }
            }      
        }
    }
}
