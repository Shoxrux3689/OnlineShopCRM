using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.SaleProductModels;

namespace OnlineShopCRM.Controllers;

[Route("api/customers/{customerId}/[controller]")]
[ApiController]
public class SaleProductsController : ControllerBase
{
    private readonly ISaleProductManager _saleProductManager;

    public SaleProductsController(ISaleProductManager saleProductManager)
    {
        _saleProductManager = saleProductManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSaleProduct(int customerId, CreateSaleProduct createSaleProduct)
    {
        try
        {
            await _saleProductManager.CreateSaleProduct(customerId, createSaleProduct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> GetSaleProductById(int customerId, int saleProductId)
    {

    }
}
