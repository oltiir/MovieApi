using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieApiController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetMovieForecast")]
    public IEnumerable<MovieForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new MovieApi
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    } 
}
