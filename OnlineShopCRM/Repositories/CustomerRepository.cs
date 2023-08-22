using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer.Id;
    }

    public async Task<List<Customer>?> GetCustomerByFilter(CustomerFilter customerFilter)
    {
        var query = _dbContext.Customers.AsQueryable();

        if (!string.IsNullOrWhiteSpace(customerFilter.FirstName))
            query = query.Where(c => c.FirstName.Contains(customerFilter.FirstName));

        if (!string.IsNullOrWhiteSpace(customerFilter.LastName))
            query = query.Where(c => c.LastName.Contains(customerFilter.LastName));

        if (!string.IsNullOrWhiteSpace(customerFilter.Address))
            query = query.Where(c => c.Address.Contains(customerFilter.Address));

        if (!string.IsNullOrWhiteSpace(customerFilter.PhoneNumber))
            query = query.Where(c => c.PhoneNumber.Contains(customerFilter.PhoneNumber));

        return await query.ToListAsync();
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        return customer;
    }

    public async Task UpdateCustomer(Customer customer)
    {
        _dbContext.Update(customer);
        await _dbContext.SaveChangesAsync();
    }
}
