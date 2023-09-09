using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.SaleModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class SaleManager : ISaleManager
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    public SaleManager(ISaleRepository saleRepository, ICustomerRepository customerRepository)
    {
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
    }

    public async Task CreateSale(int customerId, CreateSale createSale)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var sale = createSale.Adapt<Sale>();
        sale.CustomerId = customerId;
        
        await _saleRepository.CreateSale(sale);
    }

    public async Task<Sale?> GetSale(int saleId)
    {
        var sale = await _saleRepository.GetSaleById(saleId);
        return sale;
    }

    public async Task<List<Sale>?> GetSalesByCustomerId(int customerId)
    {
        var sales = await _saleRepository.GetSalesByCustomerId(customerId);
        return sales;
    }

    public async Task<List<Sale>?> GetSalesByFilter(SaleFilter saleFilter)
    {
        var sales = await _saleRepository.GetSalesByFilter(saleFilter);
        return sales;
    }

    public async Task UpdateSale(int saleId, UpdateSale updateSale)
    {
        var sale = await _saleRepository.GetSaleById(saleId);
        if (sale == null) 
            throw new Exception("Sale is not found");
        
        sale.SaleDate = updateSale.SaleDate;
        sale.Price = updateSale.Price;
        sale.Name = updateSale.Name;

        await _saleRepository.UpdateSale(sale);
    }
}

