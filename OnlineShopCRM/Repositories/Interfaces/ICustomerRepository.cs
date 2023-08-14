using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface ICustomerRepository
{
    public Task<Customer?> GetCustomerById(int id);
    public Task<List<Customer>?> GetCustomerByFilter();
    public Task<int> CreateCustomer(Customer customer);
    public Task UpdateCustomer(Customer customer);
}
