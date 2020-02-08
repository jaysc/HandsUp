using Microsoft.AspNetCore.Mvc;
using HandsUp.Shared.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HandsUp.Server.Controllers
{
    [ApiController]
    public class WeatherForecastController : Controller
    {
        [Route("weatherForecast")]
        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> WeatherForecast()
        {
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(System.IO.File.ReadAllText("weather.json"));
        }

        [Route("helloworld")]
        public ActionResult<string> Helloworld()
        {
            var text = System.IO.File.ReadAllText("weather.json");
            return text;
        }
    }
}
