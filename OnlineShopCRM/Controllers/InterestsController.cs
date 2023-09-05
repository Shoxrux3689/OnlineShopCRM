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

    [HttpGet("{interestId}")]
    public async Task<IActionResult> GetInterest(int interestId)
    {
        var interest = await _interestManager.GetInterestById(interestId);
        if (interest == null)
        {
            return NotFound("Interest is not found");
        }

        return Ok(interest);
    }

    [HttpGet]
    public async Task<IActionResult> GetInterestsByCustomerId(int customerId)
    {
        try
        {
            var interests = await _interestManager.GetInterestsByCustomerId(customerId);
            return Ok(interests);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{interestId}")]
    public async Task<IActionResult> UpdateInterest(int customerId, int interestId)
    {
        try
        {
            await _interestManager.UpdateInterest()
        }
    }
}
