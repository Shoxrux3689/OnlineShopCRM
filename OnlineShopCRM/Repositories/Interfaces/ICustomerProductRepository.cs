namespace OnlineShopCRM.Repositories.Interfaces;

public interface ICustomerProductRepository
{
    Task AddCustomerProduct(int customerId, int productId);
}
