using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.ProductModels;
using OnlineShopCRM.Providers;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>?> GetProductsByFilter(ProductFilter productFilter)
    {
        var query = _context.Products.AsQueryable();

        if (productFilter.ProductName != null)
            query = query.Where(p => p.Name.Contains(productFilter.ProductName));

        if (productFilter.FromProductPrice != null && productFilter.FromProductPrice != null)
            query = query.Where(p => p.Price > productFilter.FromProductPrice && p.Price <= productFilter.ToProductPrice);

        if (productFilter.FromProductPrice != null && productFilter.FromProductPrice == null)
            query = query.Where(p => p.Price > productFilter.FromProductPrice);

        if (productFilter.FromProductPrice == null && productFilter.FromProductPrice != null)
            query = query.Where(p => p.Price <= productFilter.ToProductPrice);

        return await query.ToListAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}
