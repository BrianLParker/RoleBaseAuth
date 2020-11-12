namespace RoleBaseAuth.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RoleBaseAuth.Server.Models;

    [Authorize(Policy = "MarsOnlyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class PlanetWeatherForecastController : BaseWeatherForecastController<WeatherForecastController>
    {
        public PlanetWeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger) { }
        protected override string[] Summaries
            => new[] { "Freezing", "Solar Flares", "Dust Storms", "Cool", "Mild", "Warm 👽", "Balmy", "Hot", "Small Tornadoes", "Dry Ice" };
        protected override int ReturnCount => 7;
    }
}
