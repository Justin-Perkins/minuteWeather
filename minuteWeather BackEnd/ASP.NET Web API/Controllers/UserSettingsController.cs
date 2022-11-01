using Microsoft.AspNetCore.Mvc;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UserSettingsController : ControllerBase
{

    private readonly ILogger<UserSettingsController> _logger;

    public UserSettingsController(ILogger<UserSettingsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUserSettings")]
    public IEnumerable<UserSettings> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new UserSettings
        {
            alertTime = DateTime.Now.TimeOfDay,
	        temp = 1,
	        humidity = 1,
	        precipitation = 0,
	        wind = 1,
	        uv = 0
        })
        .ToArray();
    }

}