using OnlineShopCRM.Entities;
using OnlineShopCRM.Models.InterestModels;

namespace OnlineShopCRM.Managers.Interfaces;

public interface IInterestManager
{
    Task CreateInterest(CreateInterestModel createInterestModel);
    Task<Interest?> GetInterestByCustomerId(int customerId);
    Task<Interest?> GetInterestById(int interestId);
    Task<List<Interest>?> GetInterestsByCustomerId(int customerId);
    Task UpdateInterest(int customerId, UpdateInterestModel updateInterestModel);
}
