using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IOrderProductManager
{
    Task<int> CreateOrderProduct(int orderId, int productId);
    Task<List<OrderProduct>?> GetOrderProducts(int orderId, int productId);
    Task DeleteOrderProduct(int orderProductId);
}
