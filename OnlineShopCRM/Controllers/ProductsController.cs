using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.ProductModels;

namespace OnlineShopCRM.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductManager _productManager;

    public ProductsController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductModel createProductModel)
    {
        try
        {
            var productId = await _productManager.CreateProduct(createProductModel);
            return Created("", new { Id = productId });
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        try
        {
            var product = await _productManager.GetProductById(productId);
            if (product == null)
                return NotFound("Product is not found!");

            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProductByFilter([FromQuery]ProductFilter productFilter)
    {
        try
        {
            var products = await _productManager.GetProductByFilter(productFilter);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct(int productId, UpdateProductModel updateProductModel)
    {
        try
        {
            await _productManager.UpdateProduct(productId, updateProductModel);
            return Ok(productId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
