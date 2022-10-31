using Microsoft.AspNetCore.Mvc;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UserLoginController : ControllerBase
{

    private readonly ILogger<UserLoginController> _logger;

    public UserLoginController(ILogger<UserLoginController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUserLogin")]
    public IEnumerable<UserLogin> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new UserLogin
        {
            username = "root",
            password = "password"
        })
        .ToArray();
    }

}