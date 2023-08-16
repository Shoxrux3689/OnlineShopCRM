using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class CutomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CutomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer.Id;
    }

    public async Task<List<Customer>?> GetCustomerByFilter()
    {
        return await _dbContext.Customers.ToListAsync();
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
