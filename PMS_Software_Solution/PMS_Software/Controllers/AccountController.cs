using Entities;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;

namespace PMS_Software.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _userService;
        private readonly PMS_DBContext _pMS_DBContext;
        public AccountController(IUsersService userService,PMS_DBContext pMS_DBContext)
        { 
            _userService= userService;
            _pMS_DBContext= pMS_DBContext;
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
            return View("Login");
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
            return RedirectToAction("Login");
        }
        [Route("forget_password")]
        public  IActionResult ForgetPassword()
        {
            return  View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPatch]
        [Route("Account/Update/{field}/{value}")]
        public async Task<IActionResult> ProfileUpdate(string field,string value)
        {
            var user =await  _pMS_DBContext.ApplicationUsers.FirstOrDefaultAsync(user=>user.UserName==User.Identity.Name);

            if (field == "FirstName")
            {
                user.FirstName= value;
            }
            else if (field == "LastName")
            {
                user.LastName=value;
            }
            else if (field == "UserAddress")
            {
                user.UserAddress = value;
            }
            else if (field == "JobTitle")
            {
                user.JobTitle=value;
            }
            else if (field == "JobDescription")
            {
                user.JobDescription=value;
            }
            else if (field == "JobStatus")
            {
                user.JobStatus=value;
            }
            else if(field == "Department")
            {
                user.Department =value;
            }
            else if(field == "Organization")
            {
                user.Organization=value;
            }
            await _pMS_DBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
