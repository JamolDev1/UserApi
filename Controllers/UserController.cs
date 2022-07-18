using Databasesql.Entities;
using Databasesql.Models;
using Databasesql.Services;
using Microsoft.AspNetCore.Mvc;

namespace Databasesql.Controllers;
[ApiController]
[Route("api/controller")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _service;

    public UserController(ILogger <UserController> logger, UserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("/Adduser")]
    public async Task<IActionResult> AddUser ([FromForm]UserModel model)
    {
        var user = new User{
           Id = Guid.NewGuid(),
           FirstName = model.FirstName,
           LastName = model.LastName,
           PhoneNumber = model.PhoneNumber,
           Age = model.Age,
           Gender = model.Gender
        };
        var result = await _service.InsertAsync(user);
        var error = !result.IsSuccess;
        var massage = result.e is null ? "Success " : result.e.Message;
        return Ok(new { error , massage , user});
    }
    [HttpGet("/GetAllUser")]
    public async Task<IActionResult> GetAllUser()
    {
        var res = await _service.GetAllAsync();
        return Ok(res);
    }
    [HttpGet("/getbyuserid")]
    public async Task<IActionResult> GetByUserId(Guid id)
    {
        var res = await _service.GetByIdAsync(id);
        return Ok(res);
    }
    [HttpPut("/Updateuserbyid")]
    public async Task<IActionResult> UpdateUserById([FromForm]UserModel model, Guid id)
    {
        var res = await _service.GetByIdAsync(id);
        res.FirstName = model.FirstName;
        res.LastName= model.LastName;
        res.PhoneNumber= model.PhoneNumber;
        res.Age= model.Age;
        res.Gender= model.Gender;
        var result = await _service.UpdateAsync(res);

        var error = !result.IsSuccess;
        var message = result.e is null ? "Success" : result.e.Message;
        return Ok(new{error , message});
    } 
    [HttpDelete("/deleteuser")]
    public async Task<IActionResult> DeleteUser (Guid id)
    {
        var res = await _service.DeleteAsync(id);
        return Ok(res);
    }
}