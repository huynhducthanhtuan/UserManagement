using Microsoft.AspNetCore.Mvc;
using UserMgmt.Sdk.Models;
using UserMgmt.Sdk.Services;

namespace UserMgmt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IUserMgmtClient _sdk;

    public EmployeesController(IUserMgmtClient sdk)
    {
        _sdk = sdk;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        try
        {
            var users = await _sdk.GetUsersAsync();
            return Ok(users);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<User>> Get(string name)
    {
        try
        {
            var user = await _sdk.GetUserAsync(name);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
