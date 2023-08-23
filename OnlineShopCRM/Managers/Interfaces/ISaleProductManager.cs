using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models.SaleProductModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ISaleProductManager
{
    Task CreateSaleProduct(int customerId, CreateSaleProduct createSaleProduct);
    Task<SaleProduct?> GetSaleProduct(SaleProduct? product);
    Task<List<SaleProduct>?> GetSaleProductsByCustomerId(int customerId);
    Task<List<SaleProduct>?> GetSaleProductsByFilter(SaleProductFilter saleProductFilter);
    Task UpdateSaleProduct(UpdateSaleProduct saleProduct);

}
