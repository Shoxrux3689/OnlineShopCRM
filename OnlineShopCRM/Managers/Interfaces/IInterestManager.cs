using OnlineShopCRM.Entities;
using OnlineShopCRM.Models.InterestModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IInterestManager
{
    Task<int> CreateInterest(int customerId, CreateInterestModel createInterestModel);
    Task<Interest?> GetInterestById(int interestId);
    Task<List<Interest>?> GetInterestsByCustomerId(int customerId);
    Task UpdateInterest(int customerId, int interestId, UpdateInterestModel updateInterestModel);
}
