using Entities;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using OfficeOpenXml;
using ServiceContracts;
using ServiceContracts.DTO.BoardDTO;
using ServiceContracts.DTO.SprintDTO;
using Services.ProjectServices;

namespace PMS_Software.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
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
        public IActionResult ActiveSprints()
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
        public async Task<IActionResult> UploadIssuesFromExcel(AddIssuesByExeleRequest addIssuesByExeleRequest)
        {
            var projectId = ViewData["projectId"];


            if (addIssuesByExeleRequest.ExcelFile !=null && addIssuesByExeleRequest.ExcelFile.Length > 0)
            {
                using(var stream =  new MemoryStream())
                {
                    addIssuesByExeleRequest.ExcelFile.CopyTo(stream);
                    using(var package= new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        List<Issue> issues = new List<Issue>();
                        List<TempIssue> tempIssues = new List<TempIssue>();
                        int rowCount = worksheet.Dimension.Rows;
                        if (addIssuesByExeleRequest.SelectedSprintId=="Backlog")
                        {
                            for (int row = 2; row <= rowCount; row++)
                            {
                                tempIssues.Add(new TempIssue()
                                {
                                    Description = worksheet.Cells[row, 1].Value.ToString(),
                                    State = worksheet.Cells[row, 2].Value.ToString(),
                                    Priority = worksheet.Cells[row, 3].Value.ToString(),
                                    IssueType = worksheet.Cells[row, 4].Value.ToString(),
                                    BoardId = Guid.Parse(addIssuesByExeleRequest.BoardId)
                                });
                            }
                           List<TempIssue> result = await _boardService.AddtempIssues(tempIssues);
                           if(result!=null)
                            {
                                return RedirectToAction("BacklogPage", "Board", new { projectId = projectId, boardId = addIssuesByExeleRequest.BoardId });
                            }
                        }
                        else
                        {
                            for (int row = 2; row <= rowCount; row++)
                            {
                                issues.Add(new Issue()
                                {
                                    Description = worksheet.Cells[row, 1].Value.ToString(),
                                    State = worksheet.Cells[row, 2].Value.ToString(),
                                    Priority = worksheet.Cells[row, 3].Value.ToString(),
                                    IssueTye = worksheet.Cells[row, 4].Value.ToString(),
                                    SprintId = Guid.Parse(addIssuesByExeleRequest.SelectedSprintId)
                                });
                            }
                            List<Issue> res= await _boardService.AddIssues(issues);
                            if(res!=null)
                            {
                                return RedirectToAction("BacklogPage", "Board", new { projectId = projectId, boardId = addIssuesByExeleRequest.BoardId });
                                
                            }
                        }

                    }
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSprintInfo(SprintUpdateRequest sprintUpdateRequest)
        {
            ViewData["boardId"] = sprintUpdateRequest.BoardId;
            if(ModelState.IsValid)
            {
                var board = await _boardService.GetBoardByBoardId((Guid)sprintUpdateRequest.BoardId);
                if (sprintUpdateRequest != null)
                {
                    await _boardService.UpdateSprint(sprintUpdateRequest);
                }
                return RedirectToAction("BacklogPage", "Board", new { projectId = board.ProjectId, boardId = sprintUpdateRequest.BoardId });
            }
            
            return View("SprintEditModal");
        }

    }
}
