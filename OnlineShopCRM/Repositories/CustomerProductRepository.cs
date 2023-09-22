using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class CustomerProductRepository : ICustomerProductRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddCustomerProduct(int customerId, int productId)
    {
        var customerProduct = new CustomerProduct() 
        { 
            CustomerId = customerId,
            ProductId = productId 
        };

        _appDbContext.CustomerProducts.Add(customerProduct);
        await _appDbContext.SaveChangesAsync();
    }

}
