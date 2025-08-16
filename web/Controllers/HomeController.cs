using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Models;
using System.Text.Json;

namespace web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Forecast()
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("http://api:8080/weatherforecast");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var weatherForecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(json, options);
                
                ViewData["Message"] = "Weather forecast data retrieved successfully.";
                ViewData["Forecast"] = weatherForecasts;
            }
            else
            {
                ViewData["Message"] = "Failed to retrieve weather forecast data.";
                ViewData["Forecast"] = new List<WeatherForecast>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather forecast");
            ViewData["Message"] = "Error occurred while fetching weather forecast data.";
            ViewData["Forecast"] = new List<WeatherForecast>();
        }
        
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
