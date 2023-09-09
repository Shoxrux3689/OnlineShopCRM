using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class InterestRepository : IInterestRepository
{
    private readonly AppDbContext _appDbContext;

    public InterestRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateInterest(Interest interest)
    {
        _appDbContext.Interests.Add(interest);
        await _appDbContext.SaveChangesAsync();
        return interest.Id;
    }

    public async Task<Interest?> GetInterestById(int customerId)
    {
        var interest = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.CustomerId == customerId);
        return interest;
    }

    public async Task<List<Interest>?> GetInterestsByCustomerId(int customerId)
    {
        var interests = await _appDbContext.Interests.Where(i => i.CustomerId == customerId).ToListAsync();
        return interests;
    }

    public async Task UpdateInterest(Interest interest)
    {
        _appDbContext.Interests.Update(interest);
        await _appDbContext.SaveChangesAsync();
    }
}
