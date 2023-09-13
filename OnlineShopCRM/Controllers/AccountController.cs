using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopCRM.Managers;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.UserModels;

namespace OnlineShopCRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserManager _userManager;

    public AccountController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("register")]
    public async Task<IActionResult> Registration(CreateUserModel createUserModel)
    {
        try
        {
            var id = await _userManager.Registration(createUserModel);
            return Created("", new { Id = id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginUserModel loginUserModel)
    {
        try
        {
            var token = await _userManager.Login(loginUserModel);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        //httpcontext dan id sini olish kere

    }
}
