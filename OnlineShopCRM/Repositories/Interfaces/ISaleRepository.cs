using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface ISaleRepository
{
    public Task<int> CreateSale(Sale sale);
    public Task<Sale?> GetSaleById(int id);
    public Task<List<Sale>?> GetSalesByFilter(SaleFilter saleFilter);
    public Task<List<Sale>?> GetSalesByCustomerId(int customerId);
    public Task UpdateSale(Sale sale);
}
