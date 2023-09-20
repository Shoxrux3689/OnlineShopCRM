using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.ProductModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IProductManager
{
    Task<int> CreateProduct(CreateProductModel createProductModel);
    Task UpdateProduct(int productId, UpdateProductModel updateProductModel);
    Task<Product?> GetProductById(int productId);
    Task<List<Product>?> GetProductByFilter(ProductFilter productFilter);
}
