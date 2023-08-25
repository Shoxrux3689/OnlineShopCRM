using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.CustomerModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerManager _customerManager;

    public CustomersController(ICustomerManager customerManager)
    {
        _customerManager = customerManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerModel createCustomerModel)
    {
        try
        {
            var customerId = await _customerManager.CreateCustomer(createCustomerModel);
            return Created("", new {Id = customerId});
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers(CustomerFilter customerFilter)
    {
        var customers = await _customerManager.GetCustomers(customerFilter);
        return Ok(customers);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomer(int customerId)
    {
        var customer = await _customerManager.GetCustomer(customerId);
        if (customer == null)
        {
            return NotFound("Customer is not found!");
        }

        return Ok(customer);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(int customerId, UpdateCustomerModel updateCustomerModel)
    {
        try
        {
            await _customerManager.UpdateCustomer(customerId, updateCustomerModel);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
