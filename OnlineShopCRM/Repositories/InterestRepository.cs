using OnlineShopCRM.Entities;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Repositories;

public class InterestRepository : IInterestRepository
{
    public Task<int> CreateInterest(Interest interest)
    {
        throw new NotImplementedException();
    }

    public Task<Interest?> GetInterestByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Interest>?> GetInterestsByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInterest(int id)
    {
        throw new NotImplementedException();
    }
}
