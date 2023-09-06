using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Managers.Interfaces;

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

    [HttpGet]
    public async Task<IActionResult> CreateSaleProduct()
    {
        try
        {
            await _saleProductManager.CreateSaleProduct();
        }
        return
    }
}
