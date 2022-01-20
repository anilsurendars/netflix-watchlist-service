using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflexWatchList.Shared.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetflexWatchList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IApplicationTime _appTime;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IApplicationTime applicationTime)
        {
            _logger = logger;
            _appTime = applicationTime;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = _appTime.GetDate().AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
