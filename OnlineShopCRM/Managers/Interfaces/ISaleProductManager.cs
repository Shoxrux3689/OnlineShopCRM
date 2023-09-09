using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.SaleProductModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ISaleProductManager
{
    Task CreateSaleProduct(int customerId, CreateSaleProduct createSaleProduct);
    Task<Sale?> GetSaleProduct(int saleProductId);
    Task<List<Sale>?> GetSaleProductsByCustomerId(int customerId);
    Task<List<Sale>?> GetSaleProductsByFilter(SaleProductFilter saleProductFilter);
    Task UpdateSaleProduct(int saleProductId, UpdateSaleProduct saleProduct);
}
