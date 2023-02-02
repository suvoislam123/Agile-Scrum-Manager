using Entities;
using Microsoft.AspNetCore.Mvc;

namespace PMS_Software.Controllers
{
    public class AccountController : Controller
    {
        [Route("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if(ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
