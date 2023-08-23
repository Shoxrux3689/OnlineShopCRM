using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.SaleProductModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class SaleProductManager : ISaleProductManager
{
    private readonly ISaleProductRepository _saleProductRepository;
    private readonly ICustomerRepository _customerRepository;
    public SaleProductManager(ISaleProductRepository saleProductRepository, ICustomerRepository customerRepository)
    {
        _saleProductRepository = saleProductRepository;
        _customerRepository = customerRepository;
    }

    public async Task CreateSaleProduct(int customerId, CreateSaleProduct createSaleProduct)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var saleProduct = createSaleProduct.Adapt<SaleProduct>();
        saleProduct.CustomerId = customerId;
        
        await _saleProductRepository.CreateSaleProduct(saleProduct);
    }

    public async Task<SaleProduct?> GetSaleProduct(int saleProductId)
    {
        var saleProduct = await _saleProductRepository.GetSaleProductById(saleProductId);
        return saleProduct;
    }

    public async Task<List<SaleProduct>?> GetSaleProductsByCustomerId(int customerId)
    {
        var saleProducts = await _saleProductRepository.GetSaleProductsByCustomerId(customerId);
        return saleProducts;
    }

    public async Task<List<SaleProduct>?> GetSaleProductsByFilter(SaleProductFilter saleProductFilter)
    {
        var saleProducts = await _saleProductRepository.GetSaleProductsByFilter(saleProductFilter);
        return saleProducts;
    }

    public async Task UpdateSaleProduct(int saleProductId, UpdateSaleProduct updateSaleProduct)
    {
        var saleProduct = await _saleProductRepository.GetSaleProductById(saleProductId);
        if (saleProduct == null) 
            throw new Exception("SaleProduct is not found");
        
        saleProduct.SaleDate = updateSaleProduct.SaleDate;
        saleProduct.Price = updateSaleProduct.Price;
        saleProduct.Name = updateSaleProduct.Name;

        await _saleProductRepository.UpdateSaleProduct(saleProduct);
    }
}

