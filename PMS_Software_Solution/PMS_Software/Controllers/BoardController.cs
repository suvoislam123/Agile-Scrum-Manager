using Entities;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using ServiceContracts;
using ServiceContracts.DTO.BoardDTO;
using Services.ProjectServices;

namespace PMS_Software.Controllers
{
    public class BoardController : Controller
    {

        /*private readonly BoardService _boardService;
        public BoardController(BoardService boardService)
        { 
            _boardService = boardService;
            
        }*/
        private readonly IBoardService _boardService;
        private readonly IProjectService _projectService;
        public BoardController(IBoardService boardService, IProjectService projectService)
        {
            _boardService = boardService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/projects/{projectId}/board/create")]
            
        public async Task<IActionResult> Create(Guid projectid)
        {
            ViewBag.ProjectId = projectid;
            return View();
        }
        [HttpPost]
        [Route("/board/create")]
        public async Task<IActionResult> CreateBoard(BoardAddRequest boardAddRequest)
        {
            if(!ModelState.IsValid)
            {
                return View("Create");
            }
            await _boardService.AddBoardAsync(boardAddRequest, User);
            return RedirectToAction("Index", "Project");

        }
        [HttpGet]
        [Route("/projects/{projectId}/boards/{boardId}/backlog")]
        public async Task<IActionResult> BacklogPage(Guid projectId,Guid boardId)
        {
            ViewData["project"] = await _projectService.LaunchProject(projectId);
            var boards = await _boardService.GetBoardsByProjectId(projectId);
            ViewData["boards"] = boards;
            ViewData["boardId"] = boardId;
            ViewData["sprints"] = _boardService.GetSprintsByBoardId(boardId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBacklog(BacklogAddRequest backlogAddRequest)
        {

            if (backlogAddRequest.SprintId.ToString() != "Backlog" && backlogAddRequest.SprintId != null)
            {
                var issue = backlogAddRequest.ToIssue();
                await _boardService.AddIssueAtSprint((Guid)backlogAddRequest.SprintId, issue);
                return RedirectToAction("BacklogPage", "Board", new { projectId = backlogAddRequest.ProjectId, boardId = backlogAddRequest.BoardId });
            }
            else
            {
                var tempIssue = backlogAddRequest.ToTempIssue();
                await _boardService.AddTempIssueAtBoard((Guid)backlogAddRequest.BoardId, tempIssue);

            }
            return RedirectToAction("BacklogPage", "Board", new { projectId = backlogAddRequest.ProjectId, boardId = backlogAddRequest.BoardId });
           
        }
        [HttpDelete]
        [Route("/Issue/Delete/{Id}")]
        public async Task<IActionResult> DeleteIssueAsync(Guid Id)
        {
            var issue = await _boardService.DeleteIssueByIssueId(Id);
            if (issue != null)
                return Ok();
            return NotFound();
        }

    }
}
