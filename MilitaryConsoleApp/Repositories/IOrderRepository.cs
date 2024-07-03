namespace MilitaryConsoleApp.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Models.Order>> GetOrdersAsync();
    }
}
