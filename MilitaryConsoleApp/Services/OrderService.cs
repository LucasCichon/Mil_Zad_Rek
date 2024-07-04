using MilitaryConsoleApp.Repositories;

namespace MilitaryConsoleApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Models.Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}
