using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Error404()
        {
            return View();
        }
    }
}