using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly AppDbContext _appDbContext;

    public SaleProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateSaleProduct(SaleProduct saleProduct)
    {
        _appDbContext.SaleProducts.Add(saleProduct);
        await _appDbContext.SaveChangesAsync();
        return saleProduct.Id;
    }

    public async Task<SaleProduct?> GetSaleProductById(int id)
    {
        return await _appDbContext.SaleProducts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SaleProduct>?> GetSaleProductsByCustomerId(int customerId)
    {
        var saleProducts = await _appDbContext.SaleProducts.Where(s => s.CustomerId == customerId).ToListAsync();
        return saleProducts;
    }

    public Task<List<SaleProduct>?> GetSaleProductsByFilter(SaleProductFilter filter)
    {
        return new List<SaleProduct>();
    }

    public async Task UpdateSaleProduct(SaleProduct saleProduct)
    {
        _appDbContext.SaleProducts.Update(saleProduct);
        await _appDbContext.SaveChangesAsync();
    }
}
