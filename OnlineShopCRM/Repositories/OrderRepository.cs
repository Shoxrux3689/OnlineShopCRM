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

    public async Task<int> CreateSale(Sale sale)
    {
        _appDbContext.Sales.Add(sale);
        await _appDbContext.SaveChangesAsync();
        return sale.Id;
    }

    public async Task<Sale?> GetSaleById(int id)
    {
        return await _appDbContext.Sales.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Sale>?> GetSalesByCustomerId(int customerId)
    {
        var sales = await _appDbContext.Sales.Where(s => s.CustomerId == customerId).ToListAsync();
        return sales;
    }

    public async Task<List<Sale>?> GetSalesByFilter(SaleFilter filter)
    {
        var query = _appDbContext.Sales.Include(s => s.Customer).AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(s => s.Name.Contains(filter.Name));

        if (!string.IsNullOrWhiteSpace(filter.CustomerPhoneNumber))
            query = query.Where(s => s.Customer!.PhoneNumber.Contains(filter.CustomerPhoneNumber));

        if (filter.FromSaleDate != null && filter.ToSaleDate != null)
            query = query.Where(s => s.SaleDate > filter.FromSaleDate && s.SaleDate <= filter.ToSaleDate);
        
        if (filter.FromSaleDate != null && filter.ToSaleDate == null)
            query = query.Where(s => s.SaleDate > filter.FromSaleDate);

        if (filter.FromSaleDate == null && filter.ToSaleDate != null)
            query = query.Where(s => s.SaleDate < filter.ToSaleDate);

        if (filter.FromPrice != null && filter.ToPrice != null)
            query = query.Where(s => s.Price > filter.FromPrice && s.Price <= filter.ToPrice);
        
        if (filter.FromPrice != null && filter.ToPrice == null)
            query = query.Where(s => s.Price > filter.FromPrice);

        if (filter.FromPrice == null && filter.ToPrice != null)
            query = query.Where(s => s.Price <= filter.ToPrice);

        return await query.ToListAsync();
    }

    public async Task UpdateSale(Sale sale)
    {
        _appDbContext.Sales.Update(sale);
        await _appDbContext.SaveChangesAsync();
    }
}
