using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindeWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries =
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  private readonly ILogger<WeatherForecastController> _logger;

  public WeatherForecastController(ILogger<WeatherForecastController> logger)
  {
    _logger = logger;
  }


  [Authorize]
  [HttpGet("Protected", Name = "GetWeatherForecastProtected")]
  public IEnumerable<WeatherForecast> GetProtected()
  {
    var user = HttpContext.User;
    return Enumerable.Range(1, 4).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
  }

  [Authorize(Policy = "ReadWeatherPermission")]
  [HttpGet("PermissionProtected", Name = "GetWeatherForecastPermissionProtected")]
  public IEnumerable<WeatherForecast> GetPermissionProtected()
  {
    return Enumerable.Range(1, 2).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 0),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
  }

  [Authorize(Policy = "AdminRole")]
  [HttpGet("RoleProtected", Name = "GetWeatherForecastRoleProtected")]
  public IEnumerable<WeatherForecast> GetRoleProtected()
  {
    return Enumerable.Range(1, 3).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(30, 45),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
  }

  [HttpGet("Public", Name = "GetWeatherForecastPublic")]
  public IEnumerable<WeatherForecast> GetPublic()
  {
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(16, 32),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
  }
}
