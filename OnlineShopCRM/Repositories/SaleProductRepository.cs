using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    public Task<int> CreateSaleProduct(SaleProduct saleProduct)
    {
        throw new NotImplementedException();
    }

    public Task<SaleProduct?> GetSaleProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SaleProduct>?> GetSaleProductsByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<SaleProduct>?> GetSaleProductsByFilter(SaleProductFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSaleProduct(SaleProduct saleProduct)
    {
        throw new NotImplementedException();
    }
}
