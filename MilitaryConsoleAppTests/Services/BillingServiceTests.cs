using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Models;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.ErrorHandling;
using MilitaryConsoleApp.Repositories;
using MilitaryConsoleApp.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TddXt.AnyRoot.Root;
using MilitaryConsoleApp.Common;
using NSubstitute;
using MilitaryConsoleApp.Clients;


namespace MilitaryConsoleAppTests.Services
{
    public class BillingServiceTests
    {
        private Mock<IOrderService> _mockOrderService;
        private Mock<IOfferService> _mockOfferService;
        private Mock<IBillingRepository> _mockBillingRepository;
        private Mock<IAllegroClient> _mockAllegroClient;

        private BillingService _billingService;

        [SetUp]
        public void Setup()
        {
            _mockOrderService = new Mock<IOrderService>();
            _mockOfferService = new Mock<IOfferService>();
            _mockBillingRepository = new Mock<IBillingRepository>();
            _mockAllegroClient = new Mock<IAllegroClient>();

            var apiConfig = new ApiConfig { ApiUrl = Any.Instance<string>(), Token = Any.Instance<string>() };
            

            _billingService = new BillingService(
                _mockOrderService.Object,
                _mockOfferService.Object,
                _mockBillingRepository.Object,
                _mockAllegroClient.Object);
        }

        [Test]
        public async Task ProcessOffersBillingEntriesAsync_ShouldProcessOffersCorrectly_AndSaveBillings()
        {
            // Arrange
            var offers = Any.Instance<List<Offer>>();// new List<Offer> { new Offer { Id = Any.Instance<int>()} };

            _mockOfferService.Setup(x => x.GetOffersAsync()).ReturnsAsync(offers);
            _mockBillingRepository.Setup(x => x.GetBillingsAsync(It.IsAny<string>(), It.IsAny<GetBillingType>())).ReturnsAsync(Enumerable.Empty<BillingEntry>());
            _mockAllegroClient.Setup(x => x.GetBillingEntries(It.IsAny<string>(), It.IsAny<GetBillingType>())).ReturnsAsync(Any.Instance<List<BillingEntry>>());

            // Act
            await _billingService.ProcessOffersBillingEntriesAsync();

            // Assert
            _mockOfferService.Verify(x => x.GetOffersAsync(), Times.Once);
            _mockBillingRepository.Verify(x => x.GetBillingsAsync(It.IsAny<string>(), GetBillingType.ByOfferId), Times.Exactly(offers.Count));
            _mockBillingRepository.Verify(x => x.SaveBillingEntryAsync(It.IsAny<BillingEntry>()), Times.AtLeastOnce);
            _mockAllegroClient.Verify(x => x.GetBillingEntries(It.IsAny<string>(), It.IsAny<GetBillingType>()), Times.AtLeastOnce);
        }

        [Test]
        public async Task ProcessOrdersBillingEntriesAsync_ShouldProcessOrdersCorrectly_AndSaveBillings()
        {
            // Arrange
            var orders = Any.Instance<List<Order>>();
            _mockOrderService.Setup(x => x.GetOrdersAsync()).ReturnsAsync(orders);
            _mockBillingRepository.Setup(x => x.GetBillingsAsync(It.IsAny<string>(), It.IsAny<GetBillingType>())).ReturnsAsync(Enumerable.Empty<BillingEntry>());
            _mockAllegroClient.Setup(x => x.GetBillingEntries(It.IsAny<string>(), It.IsAny<GetBillingType>())).ReturnsAsync(Any.Instance<List<BillingEntry>>());

            // Act
            await _billingService.ProcessOrdersBillingEntriesAsync();

            // Assert
            _mockOrderService.Verify(x => x.GetOrdersAsync(), Times.Once);
            _mockBillingRepository.Verify(x => x.GetBillingsAsync(It.IsAny<string>(), GetBillingType.ByOrderId), Times.Exactly(orders.Count));
            _mockBillingRepository.Verify(x => x.SaveBillingEntryAsync(It.IsAny<BillingEntry>()), Times.AtLeastOnce);
            _mockAllegroClient.Verify(x => x.GetBillingEntries(It.IsAny<string>(), It.IsAny<GetBillingType>()), Times.AtLeastOnce);
        }
    }
}
