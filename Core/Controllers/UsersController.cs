using Microsoft.AspNetCore.Mvc;
using Core.Services.Interfaces;
using Core.Models;

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

    [HttpGet("login")]
    public async Task<ActionResult<User>> LogIn(string username)
    {
        var user = await _usersService.GetUserAsync(username);

        if (user == null)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(string username)
    {
        var user = await _usersService.CreateUserAsync(username);
        return Ok(user);
    }
}
