using OnlineShopCRM.Context;

namespace OnlineShopCRM.Repositories;

public class CustomerProductRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
}
