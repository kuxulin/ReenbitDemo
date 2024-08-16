using Microsoft.AspNetCore.Mvc;
using Core.Services.Interfaces;

namespace Core.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<IActionResult> LogIn(string username)
    {
        var user = await _usersService.GetUserAsync(username);

        if (user == null)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Register(string username)
    {
        var user = await _usersService.CreateUserAsync(username);
        return Ok(user);
    }
}
