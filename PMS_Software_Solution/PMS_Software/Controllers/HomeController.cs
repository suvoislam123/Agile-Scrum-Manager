using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS_Software.Models;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Diagnostics;

namespace PMS_Software.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService _userService;


        public HomeController(ILogger<HomeController> logger, IUsersService usersService)
        {
            _logger = logger;
            _userService = usersService;
        }
       
        public IActionResult Index()
        {
            
           /* List<UserResponse> users = _userService.GetAllUser();
            ViewBag.Users = users;*/
            return View();
        }

        
    }
}