using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class CutomerRepository : ICustomerRepository
{
    public Task<int> CreateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<List<Customer>?> GetCustomerByFilter()
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }
}
