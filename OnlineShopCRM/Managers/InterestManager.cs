using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.InterestModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class InterestManager : IInterestManager
{
    private readonly IInterestRepository _interestRepository;
    private readonly ICustomerRepository _customerRepository;

    public InterestManager(IInterestRepository interestRepository, ICustomerRepository customerRepository)
    {
        _interestRepository = interestRepository;
        _customerRepository = customerRepository;
    }

    public Task CreateInterest(int customerId, CreateInterestModel createInterestModel)
    {
        var interest = createInterestModel.Adapt<Interest>();
        interest.CustomerId
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
