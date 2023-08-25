using OnlineShopCRM.Entities;
using OnlineShopCRM.Models.InterestModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IInterestManager
{
    Task CreateInterest(int customerId, CreateInterestModel createInterestModel);
    Task<Interest?> GetInterestById(int interestId);
    Task<List<Interest>?> GetInterestsByCustomerId(int customerId);
    Task UpdateInterest(int interestId, UpdateInterestModel updateInterestModel);
}
