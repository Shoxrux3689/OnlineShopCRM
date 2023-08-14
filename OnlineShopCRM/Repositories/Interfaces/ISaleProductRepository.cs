using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface ISaleProductRepository
{
    public Task<int> CreateSaleProduct(SaleProduct saleProduct);
    public Task<SaleProduct?> GetSaleProductById(int id);
    public Task<List<SaleProduct>?> GetSaleProductsByFilter(SaleProductFilter filter);
    public Task<List<SaleProduct>?> GetSaleProductsByCustomerId(int customerId);
    public Task UpdateSaleProduct(SaleProduct saleProduct);
}
