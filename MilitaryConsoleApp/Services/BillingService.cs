using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.ErrorHandling;
using MilitaryConsoleApp.Models;
using MilitaryConsoleApp.Repositories;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Clients;

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
                await SaveBillings(offer.Id.ToString(), GetBillingType.ByOfferId);
            }
        }

        public async Task ProcessOrdersBillingEntriesAsync()
        {
            var orders = await _orderService.GetOrdersAsync();
            Console.WriteLine($"There are {orders.Count()} orders to process");
            foreach (var order in orders)
            {
                await SaveBillings(order.Id.ToString(), GetBillingType.ByOrderId);
            }          
        }

        private async Task SaveBillings(string id, GetBillingType type)
        {
            var billings = await _billingRepository.GetBillingsAsync(id, type);
            if (!billings.Any())
            {
                var billingEntries = await _allegroClient.GetBillingEntries(id, type);
                await _billingRepository.SaveBillingEntriesAsync(billingEntries);
            }     
        }
    }
}
