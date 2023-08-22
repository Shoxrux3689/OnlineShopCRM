using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerManager customerManager;


    [HttpGet]
    public async Task<IActionResult> GetCustomers(CustomerFilter customerFilter)
    {
        return Ok();
    }
}
