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

    public ProductRepository(AppDbContext context, IUserProvider userProvider)
    {
        _context = context;
        _userProvider = userProvider;
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

    public Task<List<Product>?> GetProductsByFilter(ProductFilter productFilter)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProduct(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}
