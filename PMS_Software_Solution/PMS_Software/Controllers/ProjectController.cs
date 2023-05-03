using Entities.Account;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO.ProjectDTO;

namespace PMS_Software.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService; 
       public ProjectController(IProjectService projectService) 
        {
            _projectService= projectService;
        }

        [Route("projects/")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectAddRequest projectAddRequest)
        {
            _projectService.AddProjectAsync(projectAddRequest, User);
            if(!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Projects");
        }
    }
}
