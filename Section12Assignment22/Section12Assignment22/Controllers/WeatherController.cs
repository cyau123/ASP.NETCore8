using Microsoft.AspNetCore.Mvc;
using Section12Assignment22.Models;
using Section12Assignment22.ServiceContracts;

namespace Section12Assignment22.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var cities = _weatherService.GetWeatherDetails();

            return View(cities);
        }

        public IActionResult City(string? cityCode)
        {
            if (string.IsNullOrWhiteSpace(cityCode))
            {
                return View();
            }

            CityWeather? city = _weatherService.GetWeatherByCityCode(cityCode);

            return View(city);
        }
    }
}
