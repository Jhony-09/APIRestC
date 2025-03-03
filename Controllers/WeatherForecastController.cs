using Microsoft.AspNetCore.Mvc;

namespace webApiTwo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> listWeatherForecasts = new List<WeatherForecast>();

    
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (listWeatherForecasts.Count == null || !listWeatherForecasts.Any())
        {
            listWeatherForecasts = Enumerable.Range(1, 100).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-0, -0),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
        }
        
    }
    

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    [Route("Get/weatherforecast2")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> GetW()
    {
       return listWeatherForecasts;
    }

    [HttpPost]
    public IActionResult Post( WeatherForecast weatherForecast)
    {
        listWeatherForecasts.Add(weatherForecast);
        return Ok(weatherForecast);
        
    }

    [HttpDelete( "{index}")]

    public IActionResult Delete(int index)
    {
        listWeatherForecasts.RemoveAt(index);
        return Ok();
    }


}
