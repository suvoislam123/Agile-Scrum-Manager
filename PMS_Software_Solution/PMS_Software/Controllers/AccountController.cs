using Entities;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace PMS_Software.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _userService;
        public AccountController(IUsersService userService)
        { 
            _userService= userService;
        }
        [Route("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        [Route("/signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(user);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
            }
            return View();
        }
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInUser signInUser)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.PasswordSignInAsync(signInUser);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(signInUser);
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
