using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.OrderModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IOrderManager
{
    Task CreateOrder(int customerId, CreateOrder createOrder);
    Task<Order?> GetOrderById(int orderId);
    Task<List<Order>?> GetOrdersByCustomerId(int customerId);
    Task<List<Order>?> GetOrdersByFilter(OrderFilter orderFilter);
    Task UpdateOrder(int customerId, int orderId, UpdateOrder order);
}
