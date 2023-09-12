using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.SaleModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ISaleManager
{
    Task CreateSale(int customerId, CreateSale createSale);
    Task<Sale?> GetSaleById(int saleId);
    Task<List<Sale>?> GetSalesByCustomerId(int customerId);
    Task<List<Sale>?> GetSalesByFilter(SaleFilter saleFilter);
    Task UpdateSale(int customerId, int saleId, UpdateSale sale);
}
