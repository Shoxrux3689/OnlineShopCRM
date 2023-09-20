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
    private readonly IUserProvider _userProvider;

    public ProductRepository(AppDbContext context, IUserProvider userProvider)
    {
        _context = context;
        _userProvider = userProvider;
    }

    public async Task<int> CreateProduct(CreateProductModel createProductModel)
    {
        var product = createProductModel.Adapt<Product>();
        product.UserId = _userProvider.UserId;

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task<Product?> GetProductById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        return product;
    }

    public Task<List<Product>?> GetProductsByFilter(ProductFilter productFilter)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProduct(Product product)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if (product == null)
        {
            throw new Exception("Product is not found!");
        }

        product = updateProductModel.Adapt<Product>();

        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}
