using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.InterestModels;

namespace OnlineShopCRM.Controllers;

[Route("api/customers/{customerId}/[controller]")]
[ApiController]
public class InterestsController : ControllerBase
{
    private readonly IInterestManager _interestManager;

    public InterestsController(IInterestManager interestManager)
    {
        _interestManager = interestManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInterest(int customerId, CreateInterestModel createInterestModel)
    {
        try
        {
            var interestId = await _interestManager.CreateInterest(customerId, createInterestModel);
            return Created("", new { Id = interestId });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetInterest()
    {
        return Ok();
    }
}
