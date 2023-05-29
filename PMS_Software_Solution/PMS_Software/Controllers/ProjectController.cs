using Entities.Account;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMS_Software.Filters.ActionFilters;
using PMS_Software.ViewModels;
using ServiceContracts;
using ServiceContracts.DTO.ProjectDTO;

namespace PMS_Software.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService; 
        private readonly IBoardService _boardService;
        private readonly IUsersService _usersService;
       public ProjectController(IProjectService projectService, IBoardService boardService,IUsersService usersService) 
        {
            _projectService= projectService;
            _boardService= boardService;
            _usersService=usersService;
            
        }

        [Route("projects/")]
        public async Task<IActionResult> Index()
        {
            var currentUser =await _usersService.GetUserByUserName(User.Identity.Name);
            List<ProjectResponse> projectsAsWoner = new List<ProjectResponse>();
            List<ProjectResponse> projectsAsGeneralUser = new List<ProjectResponse>();
            List<ProjectResponse> projectsAsLead = new List<ProjectResponse>();
            projectsAsWoner = await _projectService.GetProjectsByWoner(User);
            projectsAsGeneralUser = await _projectService.GetProjectsOfGeneraluser(currentUser.Id, User.Identity.Name);
            projectsAsLead = await _projectService.GetProjectsOfProjectLead(currentUser.Id,User.Identity.Name);
            
            var projectViewModel = new ProjectViewModel()
            {
                ProjectsAsWoner = projectsAsWoner,
                ProjectsAsGeneralUser=projectsAsGeneralUser,
                ProjectsAsLead = projectsAsLead
                
            };
            return View(projectViewModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectAddRequest projectAddRequest)
        {
            
            if(!ModelState.IsValid)
            {
                return View();
            }
           var project = await _projectService.AddProjectAsync(projectAddRequest, User);
            return RedirectToAction("Index", "Projects");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ProjectResponse projectResponse =await _projectService.GetProjectByIdAsync(id);
            return View(projectResponse.ToProjectUpdateRequest());
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateRequest projectUpdateRequest)
        {
            if(!ModelState.IsValid)
            {
                return View("Edit");
            }
            ProjectResponse projectResponse = await _projectService.UpdateProjectByIdAsync(projectUpdateRequest);
            if(projectResponse != null)
            {
                return RedirectToAction("Index","Project");
            }
            return NotFound();
        }
       
        /// <summary>
        /// Deleting a project By Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _projectService.DeleteProjectAsync(id);
            if(project != null)
            {
                return Ok();
            }
            return NotFound();
        }
        [Route("/projects/{projectId}/board/{boardId?}")]
        public async Task<IActionResult> LaunchProjectPage(Guid projectId,Guid boardId )
        {

            
            ViewData["project"] = await _projectService.LaunchProject(projectId);
            var boards = await _boardService.GetBoardsByProjectId(projectId);
            ViewData["boards"] = boards;
            ViewData["boardId"] = boardId;
            return View();
        }
    }
}
