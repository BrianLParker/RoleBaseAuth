namespace RoleBaseAuth.Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RoleBaseAuth.Shared;


    public abstract class BaseWeatherForecastController<TController> : ControllerBase where TController : BaseWeatherForecastController<TController>
    {
        public BaseWeatherForecastController(ILogger<TController> logger) => this.logger = logger;
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, ReturnCount).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        protected abstract string[] Summaries { get; }
        protected abstract int ReturnCount { get; }
        protected readonly ILogger<TController> logger;
    }
}
