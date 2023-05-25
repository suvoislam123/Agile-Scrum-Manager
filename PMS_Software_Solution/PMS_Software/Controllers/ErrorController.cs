using Microsoft.AspNetCore.Mvc;

namespace PMS_Software.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/NotFound")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
