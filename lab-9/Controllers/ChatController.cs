using Microsoft.AspNetCore.Mvc;

namespace lab_9.Controllers;

public class ChatController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}