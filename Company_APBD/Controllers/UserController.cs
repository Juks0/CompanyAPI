using Company_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Controllers;

public class UserController
{
    private readonly IDbService _dbService;

    public UserController(IDbService dbService)
    {
        _dbService = dbService;
    }
    

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        _dbService.AddUser(user);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateUser(User user)
    {
        _dbService.UpdateUser(user);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        _dbService.DeleteUser(id);
        return Ok();
    }
}