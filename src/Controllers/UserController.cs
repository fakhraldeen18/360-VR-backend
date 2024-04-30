using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;
public class UserController : CustomBaseController
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public List<User> FindAll()
    {
        return _userService.FindAll();
    }
    [HttpGet("{userId}")]
    public User? FindOne(Guid userId)
    {
        return _userService.FindOne(userId);
    }
    [HttpPost]
    public User CreateOne([FromBody] User user)
    {
        return _userService.CreateOne(user);
    }
    [HttpDelete("{userId}")]
    public User? DeleteOne(Guid userId)
    {
        return _userService.DeleteOne(userId);
    }
    [HttpPatch("{userId}")]
    public User? UpdateOne(Guid userId, [FromBody] User user)
    {
        return _userService.UpdateOne(userId, user);
    }
}