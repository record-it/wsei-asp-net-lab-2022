using Microsoft.AspNetCore.Mvc;

namespace lab_7.Controllers;

public class StatusCodeController : Controller
{
    [Route("/statuscode/{status}")]
    public IActionResult Index([FromRoute(Name = "status")] int status)
    {
        return View(status.ToString());
    }
}