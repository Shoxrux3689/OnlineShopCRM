using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Filters;
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

    [HttpGet("{saleId}")]
    public async Task<IActionResult> GetSaleById(int customerId, int saleId)
    {
        var sale = await _saleManager.GetSaleById(saleId);
        if (sale == null)
        {
            return NotFound();
        }

        return Ok(sale);
    }

    [HttpGet]
    public async Task<IActionResult> GetSalesByCustomerId(int customerId)
    {
        var sales = await _saleManager.GetSalesByCustomerId(customerId);

        return Ok(sales);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetSalesByFilter(SaleFilter saleFilter)
    {
        try
        {
            var sales = await _saleManager.GetSalesByFilter(saleFilter);
            return Ok(sales);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{saleId}")]
    public async Task<IActionResult> UpdateSale(int customerId, int saleId, UpdateSale updateSale)
    {
        try
        {
            await _saleManager.UpdateSale(customerId, saleId, updateSale);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
