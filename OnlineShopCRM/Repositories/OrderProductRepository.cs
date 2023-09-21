using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateOrderProduct(OrderProduct orderProduct)
    {
        _appDbContext.OrderProducts.Add(orderProduct);
        await _appDbContext.SaveChangesAsync();

        return orderProduct.Id;
    }

    public async Task DeleteOrderProduct(OrderProduct orderProduct)
    {
        _appDbContext.OrderProducts.Remove(orderProduct);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<OrderProduct?> GetOrderProductById(int orderProductId)
    {
        var orderProduct = await _appDbContext.OrderProducts.FirstOrDefaultAsync(x => x.Id == orderProductId);
        return orderProduct;
    }

    public async Task<List<OrderProduct>?> GetOrderProducts(int orderId, int productId)
    {
        var orderProducts = await _appDbContext.OrderProducts
            .Where(o => o.ProductId == productId && o.OrderId == orderId).ToListAsync();
        return orderProducts;
    }
}
