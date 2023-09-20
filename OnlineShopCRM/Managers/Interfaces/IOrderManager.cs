using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.OrderModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IOrderManager
{
    Task CreateOrder(int customerId, CreateOrderModel createOrder);
    Task<Order?> GetOrderById(int orderId);
    Task<List<Order>?> GetOrdersByCustomerId(int customerId);
    Task<List<Order>?> GetOrdersByFilter(OrderFilter orderFilter);
    Task UpdateOrder(int customerId, int orderId, UpdateOrderModel order);
}
