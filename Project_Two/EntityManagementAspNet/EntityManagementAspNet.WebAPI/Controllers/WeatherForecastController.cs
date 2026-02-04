using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.WebAPI.Controllers
{
    [Route("[controller]")]
    public class WeatherForecastController : Controller
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
        public IActionResult Get()
        {
            var summary = Summaries[Random.Shared.Next(Summaries.Length)];
            return Content($"Weather endpoint is disabled for JSON responses. Summary: {summary}");
        }
    }
}
