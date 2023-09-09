using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly AppDbContext _appDbContext;

    public SaleProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateSaleProduct(Sale saleProduct)
    {
        _appDbContext.SaleProducts.Add(saleProduct);
        await _appDbContext.SaveChangesAsync();
        return saleProduct.Id;
    }

    public async Task<Sale?> GetSaleProductById(int id)
    {
        return await _appDbContext.SaleProducts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Sale>?> GetSaleProductsByCustomerId(int customerId)
    {
        var saleProducts = await _appDbContext.SaleProducts.Where(s => s.CustomerId == customerId).ToListAsync();
        return saleProducts;
    }

    public async Task<List<Sale>?> GetSaleProductsByFilter(SaleProductFilter filter)
    {
        var query = _appDbContext.SaleProducts.Include(s => s.Customer).AsQueryable();

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

    public async Task UpdateSaleProduct(Sale saleProduct)
    {
        _appDbContext.SaleProducts.Update(saleProduct);
        await _appDbContext.SaveChangesAsync();
    }
}
