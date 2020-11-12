namespace RoleBaseAuth.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RoleBaseAuth.Server.Models;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseWeatherForecastController<WeatherForecastController>
    {
        public WeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger) { }
        protected override string[] Summaries
            => new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        protected override int ReturnCount => 5;
    }
}
