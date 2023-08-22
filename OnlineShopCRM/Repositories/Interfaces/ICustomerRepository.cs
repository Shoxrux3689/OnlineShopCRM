using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface ICustomerRepository
{
    public Task<Customer?> GetCustomerById(int id);
    public Task<List<Customer>?> GetCustomerByFilter(CustomerFilter customerFilter);
    public Task<int> CreateCustomer(Customer customer);
    public Task UpdateCustomer(Customer customer);
}
