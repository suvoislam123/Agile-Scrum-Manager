using Microsoft.AspNetCore.Mvc;

namespace PMS_Software.Controllers
{
    public class SprintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
