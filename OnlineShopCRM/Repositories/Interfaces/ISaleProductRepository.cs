using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface ISaleProductRepository
{
    public Task<int> CreateSaleProduct(Sale saleProduct);
    public Task<Sale?> GetSaleProductById(int id);
    public Task<List<Sale>?> GetSaleProductsByFilter(SaleProductFilter filter);
    public Task<List<Sale>?> GetSaleProductsByCustomerId(int customerId);
    public Task UpdateSaleProduct(Sale saleProduct);
}
