using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lecture_5.Models;

namespace lecture_5.Controllers;

public class HomeController : Controller
{
    private readonly Singleton _singleton;
    private readonly ILogger<HomeController> _logger;
    private int counter = 0;
    public HomeController(ILogger<HomeController> logger, Singleton singleton)
    {
        _logger = logger;
        _singleton = singleton;
    }

    public IActionResult Index()
    {
        ViewBag.Title = "Hello from Home controller";
        _logger.LogInformation("GET /: calling Index action");
        _logger.LogInformation($"Visit counter: {++counter}");
        return View();
    }
    public string Test()
    {
        return "test";
    }
    public string Time()
    {
        _logger.LogInformation($"Visited path: /Home/Time");
        string? days = this.Request.Query["days"];
        string? accept= this.Request.Headers["Accept"];
        string? method = this.Request.Method;
        string content = $"Query: days = {days}, Accept: {accept}, Method: {method}";
        return content;
    }

    public string TimeExt([FromQuery] int? days, [FromHeader] string accept)
    {
        days = days?? 5;
        string content = $"Query: days = {days}, Accept: {accept}, Method: GET";
        return content;
    }

    public string Calc(string op, double a, double b)
    {
        switch (op)
        {
            case "add":
                return $"{a} + {b} = {a + b}";
            default:
                Response.StatusCode = 400;
                return "";
        }
    }
    public string Visit()
    {
        string cookie = Request.Cookies["last-visit"]??"no";
        if (cookie == "no")
        {
            Response.Cookies.Append("last-visit", DateTime.Now.ToString());
            return "It's your first visit";
        } else
        {
            Response.Cookies.Append("last-visit", DateTime.Now.ToString());
            return $"Hello again, your last visit {cookie}";
        }
    }

    public IActionResult CalculatorForm()
    {
        return View();
    }
    
    [HttpPost]
    public string Calculator([FromForm] Calculator calculator, [FromHeader(Name = "cookie")]String cookie)
    {
        if (calculator.Calculate() == null)
        {
            Response.StatusCode = 400;
            return "Bład w nazwie parametru";
        } else
        {
            return calculator.Calculate() +" " + cookie;
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}