using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Repositories.Interfaces;

public interface IInterestRepository
{
    public Task<int> CreateInterest(Interest interest);
    public Task<Interest?> GetInterestByCustomerId(int customerId);
    public Task<Interest?> GetInterestById(int interestId);
    public Task<List<Interest>?> GetInterestsByCustomerId(int customerId);
    public Task UpdateInterest(Interest interest);
}
