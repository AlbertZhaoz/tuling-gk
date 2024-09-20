using DI注入.Filter;
using DotNet实战.AutofacCommon;
using DotNet实战.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet实战.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private IMyService _myService { get; set; }

        private IUserService _userService { get; set; }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyService myService, IUserService userService)
        {
            _logger = logger;
            _myService = myService;
            _userService = userService;
        }

        [IgnoreActionFilterAttribute]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _myService.ShowCode();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}