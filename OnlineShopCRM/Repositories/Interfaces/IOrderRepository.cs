using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IOrderRepository
{
    public Task<int> CreateOrder(Order order);
    public Task<Order?> GetOrderById(int id);
    public Task<List<Order>?> GetOrdersByFilter(OrderFilter orderFilter);
    public Task<List<Order>?> GetOrdersByCustomerId(int customerId);
    public Task UpdateOrder(Order order);
}
