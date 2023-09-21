using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class OrderProductManager : IOrderProductManager
{
    private readonly IOrderProductRepository _orderProductRepository;

    public OrderProductManager(IOrderProductRepository orderProductRepository)
    {
        _orderProductRepository = orderProductRepository;
    }

    public async Task<int> CreateOrderProduct(int orderId, int productId)
    {
        var orderProduct = new OrderProduct()
        {
            OrderId = orderId,
            ProductId = productId
        };

        return await _orderProductRepository.CreateOrderProduct(orderProduct);
    }

    public async Task DeleteOrderProduct(int orderProductId)
    {
        var orderProduct = await _orderProductRepository.GetOrderProductById(orderProductId);
        if (orderProduct == null)
            throw new Exception("Not found");

        await _orderProductRepository.DeleteOrderProduct(orderProduct);
    }

    public async Task<List<OrderProduct>?> GetOrderProducts(int orderId, int productId)
    {
        var orderProducts = await _orderProductRepository.GetOrderProducts(orderId, productId);
        return orderProducts;
    }
}
