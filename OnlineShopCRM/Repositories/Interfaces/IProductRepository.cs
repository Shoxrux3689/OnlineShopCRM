using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.ProductModels;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IProductRepository
{
    Task<int> CreateProduct(CreateProductModel createProductModel);
    Task<Product?> GetProductById(int id);
    Task<List<Product>?> GetProductsByFilter(ProductFilter productFilter);
    Task UpdateProduct(Product product);
}
