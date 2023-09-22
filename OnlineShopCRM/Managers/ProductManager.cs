using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.ProductModels;
using OnlineShopCRM.Providers;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;
    private readonly IUserProvider _userProvider;

    public ProductManager(IProductRepository productRepository, IUserProvider userProvider)
    {
        _productRepository = productRepository;
        _userProvider = userProvider;
    }

    public async Task<int> CreateProduct(CreateProductModel createProductModel)
    {
        var product = createProductModel.Adapt<Product>();
        product.UserId = _userProvider.UserId;
        
        await _productRepository.CreateProduct(product);
        return product.Id;
    }

    public async Task<List<Product>?> GetProductByFilter(ProductFilter productFilter)
    {
        var products = await _productRepository.GetProductsByFilter(productFilter);
        return products;
    }

    public async Task<Product?> GetProductById(int productId)
    {
        var product = await _productRepository.GetProductById(productId);

        return product;
    }

    public async Task UpdateProduct(int productId, UpdateProductModel updateProductModel)
    {
        var product = await _productRepository.GetProductById(productId);
        if (product == null)
            throw new Exception("Product is not found!");

        product = updateProductModel.Adapt<Product>();

        await _productRepository.UpdateProduct(product);
    }
}
