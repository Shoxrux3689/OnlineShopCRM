using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.InterestModels;

namespace OnlineShopCRM.Managers;

public class InterestManager : IInterestManager
{
    public Task CreateInterest(CreateInterestModel createInterestModel)
    {
        throw new NotImplementedException();
    }

    public Task<Interest?> GetInterestByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<Interest?> GetInterestById(int interestId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Interest>?> GetInterestsByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInterest(int customerId, UpdateInterestModel updateInterestModel)
    {
        throw new NotImplementedException();
    }
}
