﻿namespace MilitaryConsoleApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Models.Order>> GetOrdersAsync();
    }
}
