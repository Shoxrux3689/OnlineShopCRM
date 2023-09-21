using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IOrderProductRepository
{
    Task<int> CreateOrderProduct(OrderProduct orderProduct);
    Task<List<OrderProduct>?> GetOrderProducts(int orderId, int productId);
    Task<OrderProduct?> GetOrderProductById(int orderProductId);
    Task DeleteOrderProduct(OrderProduct orderProduct);
}
