using RoleBaseAuth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RoleBaseAuth.Server.Controllers
{
    [Authorize(Policy = "MarsOnlyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class PlanetWeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Solar Flares", "Dust Storms", "Cool", "Mild", "Warm", "Balmy", "Hot", "Small Tornadoes", "Dry Ice"
        };

        private readonly ILogger<AdminWeatherForecastController> logger;

        public PlanetWeatherForecastController(ILogger<AdminWeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
