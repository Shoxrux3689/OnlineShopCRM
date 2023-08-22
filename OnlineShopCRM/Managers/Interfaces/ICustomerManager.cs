using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Models;

namespace OnlineShopCRM.Managers.Interfaces;

public interface ICustomerManager
{
    Task<int> CreateCustomer(CreateCustomerModel createCustomer);
    Task<List<Customer>?> GetCustomers(CustomerFilter customerFilter);
    Task<Customer?> GetCustomer(int customerId);
    Task UpdateCustomer(int customerId, UpdateCustomerModel updateCustomer);
}
