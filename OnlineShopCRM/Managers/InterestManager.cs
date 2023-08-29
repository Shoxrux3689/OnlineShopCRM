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

    public async Task<int> CreateInterest(int customerId, CreateInterestModel createInterestModel)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var interest = createInterestModel.Adapt<Interest>();
        interest.CustomerId = customerId;
        await _interestRepository.CreateInterest(interest);
        return interest.Id;
    }


    public async Task<Interest?> GetInterestById(int interestId)
    {
        var interest = await _interestRepository.GetInterestById(interestId);
        return interest;
    }

    public async Task<List<Interest>?> GetInterestsByCustomerId(int customerId)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var interests = await _interestRepository.GetInterestsByCustomerId(customerId);
        return interests;
    }

    public async Task UpdateInterest(int interestId, UpdateInterestModel updateInterestModel)
    {
        var interest = await _interestRepository.GetInterestById(interestId);
        if (interest == null)
            throw new Exception("Interest is not found");

        interest.InterestDescription = updateInterestModel.InterestDescription;
        interest.Date = updateInterestModel.Date;
        interest.HashTags = updateInterestModel.HashTags;
        interest.IsActual = updateInterestModel.IsActual;

        await _interestRepository.UpdateInterest(interest);
    }
}
