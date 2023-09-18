using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.OrderModels;

namespace OnlineShopCRM.Controllers;

[Authorize]
[Route("api/customers/{customerId}/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderManager _orderManager;

    public OrdersController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(int customerId, CreateOrder createOrder)
    {
        try
        {
            await _orderManager.CreateOrder(customerId, createOrder);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int customerId, int orderId)
    {
        var order = await _orderManager.GetOrderById(orderId);
        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderManager.GetOrdersByCustomerId(customerId);

        return Ok(orders);
    }

    [HttpGet("filter")]
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

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(int customerId, int orderId, UpdateOrder updateOrder)
    {
        try
        {
            await _orderManager.UpdateOrder(customerId, orderId, updateOrder);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
