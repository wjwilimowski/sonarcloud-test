using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var weather = new List<WeatherForecast>();
        for (var i = 0; i < 10; i++) 
        {
            if (Random.Shared.Next() % 2 == 0) 
            {
                weather.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });
            }
        }

        if (weather.Count == 0)
            _logger.LogInformation("No weather :(");

        return weather;
    }
    
    private void DoSomething(int arg)
    {
        if (arg < 0)
        {
            throw new ArgumentException("arg should be non-negative", "arg");
        }
    }
}
