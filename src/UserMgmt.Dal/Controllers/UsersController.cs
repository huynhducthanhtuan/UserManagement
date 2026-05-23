using Microsoft.AspNetCore.Mvc;
using UserMgmt.Dal.Models;

namespace UserMgmt.Dal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> Get()
    {
        var users = new List<UserDto>()
        {
            new UserDto { Name = "alice", Email = "alice@example.com" },
            new UserDto { Name = "bob", Email = "bob@example.com" },
        };
        return Ok(users);
    }

    [HttpGet("{name}")]
    public ActionResult<UserDto> Get(string name)
    {
        var user = new UserDto { Name = name, Email = name + "@example.com" };
        return Ok(user);
    }
}