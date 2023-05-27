using Entities;
using Entities.Account;
using Entities.TeamEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS_Software.ViewModels;
using ServiceContracts;

namespace PMS_Software.Controllers
{
    public class TeamController : Controller
    {
        private readonly PMS_DBContext _pMS_DBContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUsersService _usersService;
        public TeamController(PMS_DBContext pMS_DBContext,UserManager<ApplicationUser> userManager,IUsersService usersService)
        {
            _pMS_DBContext= pMS_DBContext;
            _userManager= userManager;
            _usersService = usersService;
        }
        [Route("/teams")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SearchUsers(string searchTerm)
        {
            var users = _userManager.Users
                .Where(u => u.UserName.Contains(searchTerm))
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
                .ToList();

            return Json(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create the team
                var team = new Team
                {
                    Name = model.Name,
                    AdminUserName= model.AdminUserName,
                    Users = await _userManager.Users
                        .Where(u => model.SelectedUserIds.Contains(u.Id))
                        .ToListAsync()
                };

                // Save the team to the database
                _pMS_DBContext.Teams.Add(team);
                await _pMS_DBContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); // Redirect to the desired page
            }

            return View(model);
        }
        [Route("/teams/{id}")]
        [HttpPost]
        public async Task<IActionResult> GetUsersByTeamId(int id)
        {
            var users = await _usersService.GetApplicationUsersByTeamId(id);
            return Json(users);
        }
        [Route("/teams/delete/{teamId}/{userId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAnUserFromTeam(int teamId,string userId)
        {

            return View();
        }

    }
}
