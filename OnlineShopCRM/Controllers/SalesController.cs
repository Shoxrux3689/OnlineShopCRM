using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.SaleModels;

namespace OnlineShopCRM.Controllers;

[Route("api/customers/{customerId}/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISaleManager _saleManager;

    public SalesController(ISaleManager saleManager)
    {
        _saleManager = saleManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale(int customerId, CreateSale createSale)
    {
        try
        {
            await _saleManager.CreateSale(customerId, createSale);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> GetSaleById(int customerId, int saleId)
    {
        return Ok();
    }
}
