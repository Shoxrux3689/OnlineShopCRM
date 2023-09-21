using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateOrder(Order order)
    {
        _appDbContext.Orders.Add(order);
        await _appDbContext.SaveChangesAsync();
        return order.Id;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        return await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Order>?> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _appDbContext.Orders.Where(s => s.CustomerId == customerId).Take(20).ToListAsync();
        return orders;
    }


    public async Task<List<Order>?> GetOrdersByFilter(OrderFilter filter)
    {
        
        var query = _appDbContext.Orders.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(s => s.Product!.Name.Contains(filter.Name));

        if (!string.IsNullOrWhiteSpace(filter.CustomerPhoneNumber))
            query = query.Where(s => s.Customer!.PhoneNumber.Contains(filter.CustomerPhoneNumber));

        if (filter.FromDate != null && filter.ToDate != null)
            query = query.Where(s => s.OrderDate > filter.FromDate && s.OrderDate <= filter.ToDate);
        
        if (filter.FromDate != null && filter.ToDate == null)
            query = query.Where(s => s.OrderDate > filter.FromDate);

        if (filter.FromDate == null && filter.ToDate != null)
            query = query.Where(s => s.OrderDate < filter.ToDate);

        if (filter.FromPrice != null && filter.ToPrice != null)
            query = query.Where(s => s.Price > filter.FromPrice && s.Price <= filter.ToPrice);
        
        if (filter.FromPrice != null && filter.ToPrice == null)
            query = query.Where(s => s.Price > filter.FromPrice);

        if (filter.FromPrice == null && filter.ToPrice != null)
            query = query.Where(s => s.Price <= filter.ToPrice);
        
        return await query.ToListAsync();
    }

    public async Task UpdateOrder(Order order)
    {
        _appDbContext.Orders.Update(order);
        await _appDbContext.SaveChangesAsync();
    }
}
