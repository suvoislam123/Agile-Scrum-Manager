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
       public ProjectController(IProjectService projectService, IBoardService boardService) 
        {
            _projectService= projectService;
            _boardService= boardService;
        }

        [Route("projects/")]
        public async Task<IActionResult> Index()
        {
            List<ProjectResponse> projectsAsWoner = new List<ProjectResponse>();
            projectsAsWoner = await _projectService.GetProjectsByWoner(User);
            var projectViewModel = new ProjectViewModel()
            {
                ProjectsAsWoner = projectsAsWoner,
                
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
            _projectService.AddProjectAsync(projectAddRequest, User);
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
