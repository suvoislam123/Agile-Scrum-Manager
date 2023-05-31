using Entities.ProjectEntities;
using Microsoft.AspNetCore.Mvc;
using PMS_Software.ViewModels;
using ServiceContracts;

namespace PMS_Software.Controllers
{
    public class IssueController:Controller
    {
        private readonly IBoardService _boardService;
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService,IBoardService boardService)
        {
            _issueService= issueService;
            _boardService= boardService;
        }
        [Route("issues/{issueId}")]
        public async Task<IActionResult> Index(Guid issueId)
        {
            var issueResponse = await _issueService.GetIssueByIssueId(issueId);
            var commentViewModel = new CommentViewModel()
            {
                IssueId=issueResponse.Id,
                Comments=issueResponse.Comments
            };
            var issueviewModel = new IssueViewModel()
            {
                Name = issueResponse.Name,
                Description = issueResponse.Description,
                CommentViewModel = commentViewModel,
            };
            commentViewModel.IssueViewModel = issueviewModel;
            return View("Index", issueviewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel commentViewModelP)
        {
            if(ModelState.IsValid)
            {
                var comment = await  _issueService.AddComment(commentViewModelP.IssueId, commentViewModelP.CommentText, User.Identity.Name);
                 return RedirectToAction("Index", "Issue", new { issueId = commentViewModelP.IssueId });
            }

            var issueResponse = await _issueService.GetIssueByIssueId(commentViewModelP.IssueId);
            var issueviewModel = new IssueViewModel()
            {
                Name = issueResponse.Name,
                Description = issueResponse.Description,
                CommentViewModel = commentViewModelP,
            };
            return View("Index", issueviewModel);

        }
    }
}
