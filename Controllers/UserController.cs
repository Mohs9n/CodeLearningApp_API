using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using codegym_api.Dtos;
using codegym_api.Entities;
using codegym_api.Data;
using codegym_api.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace codegym_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
  (UserManager<User> userManager, DataContext dataContext)
  : ControllerBase
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly DataContext _dataContext = dataContext;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        User user = new()
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Type = "User",
        };

        IdentityResult result = await _userManager.CreateAsync(user, model.Password);

        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<GetUserDto>> GetUser()
    {
        var userId = User.GetUserId();
        var user = await _dataContext.Users.FindAsync(userId);

        if (user is null)
        {
            return BadRequest("User does not Exist");
        }
        GetUserDto getUserDto = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Streak = user.Streak,
            Score = user.Score,
            LoginDays = user.LoginDays,
            DoneArticles = user.DoneArticles,
        };
      return Ok(getUserDto);
    }

}
