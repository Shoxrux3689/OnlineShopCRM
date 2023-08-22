using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class CustomerManager : ICustomerManager
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerManager(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> CreateCustomer(CreateCustomerModel createCustomer)
    {
        var customer = createCustomer.Adapt<Customer>();
        var customerId = await _customerRepository.CreateCustomer(customer);
        return customerId;
    }

    public async Task<Customer?> GetCustomer(int customerId)
    {
        var customer = await _customerRepository.GetCustomerById(customerId);
        return customer;
    }

    public async Task<List<Customer>?> GetCustomers(CustomerFilter customerFilter)
    {
        var customers = await _customerRepository.GetCustomerByFilter(customerFilter);
        return customers;
    }

    public async Task UpdateCustomer(int customerId, UpdateCustomerModel updateCustomer)
    {
        var customer = await _customerRepository.GetCustomerById(customerId);
        if (customer == null)
            throw new Exception("Customer is not found!");

        customer.FirstName = updateCustomer.FirstName;
        customer.LastName = updateCustomer.LastName;
        customer.Address = updateCustomer.Address;
        customer.PhoneNumber = updateCustomer.PhoneNumber;

        await _customerRepository.UpdateCustomer(customer);
    }
}
