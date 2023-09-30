using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;

namespace OnlineShopCRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IOrderManager _orderManager;

    public ReportsController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetOrdersByFilter(OrderFilter orderFilter)
    {
        try
        {
            var orders = await _orderManager.GetOrdersByFilter(orderFilter);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
