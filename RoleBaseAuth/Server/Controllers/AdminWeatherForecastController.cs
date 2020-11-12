namespace RoleBaseAuth.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RoleBaseAuth.Server.Models;

    [Authorize(Roles = "Administrator,TenantAdmin")]
    [ApiController]
    [Route("[controller]")]
    public class AdminWeatherForecastController : BaseWeatherForecastController<AdminWeatherForecastController>
    {
        public AdminWeatherForecastController(ILogger<AdminWeatherForecastController> logger) : base(logger) { }
        protected override string[] Summaries
            => new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        protected override int ReturnCount => 10;

    }
}
