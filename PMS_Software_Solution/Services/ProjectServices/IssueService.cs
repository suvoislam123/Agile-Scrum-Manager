using Entities;
using Entities.JoinTables;
using Entities.ProjectEntities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO.IssueDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProjectServices
{
    public class IssueService:IIssueService
    {
        private readonly PMS_DBContext _pMsDbContext;
        private readonly IUsersService _usersService;
        private readonly ICommentService _commentService;
        public IssueService(PMS_DBContext pMS_DBContext, IUsersService usersService,ICommentService commentService)
        {
            _pMsDbContext = pMS_DBContext;
            _usersService = usersService;
            _commentService = commentService;
        }

        public async Task<Comment> AddComment(Guid issueId, string commentText,string userName)
        {
            var user = await _usersService.GetUserByUserName(userName);
            var comment =await  _commentService.AddComment(issueId,commentText,user);
            return comment;


        }

        /*public async Task<string> AddCommentToIssue(Guid issueId, string commentText, string userName)
        {
            var user = await _usersService.GetUserByUserName(userName);
            var issue = await _pMsDbContext.Issues
                .Include(i => i.Comments)
                .Include(i => i.AttachedLinks)
                .Include(i => i.ApplicationUserIssues)
                .FirstOrDefaultAsync(i => i.Id == (Guid)issueId);
            var newComment = new Comment()
            {
                Id = Guid.NewGuid(),
                CommentText = commentText,
                CreatedDate = DateTime.Now,
                IssueId=issueId,
            };
            var userComment = new ApplicationUserComment
            {
                ApplicationUser = user,
                Comment = newComment
            };
            
             _pMsDbContext.Comments.Add(newComment);
             _pMsDbContext.ApplicationUserComments.Add(userComment);
            
            await _pMsDbContext.SaveChangesAsync();
            return commentText;
        }*/

        public async Task<IssueReponse> GetIssueByIssueId(Guid issueId)
        {
            var issueReponse = new IssueReponse();
            var issue = await _pMsDbContext.Issues
                .Include(i=>i.Comments)
                .Include(i=>i.AttachedLinks)
                .Include(i=>i.ApplicationUserIssues)
                .FirstOrDefaultAsync(i=>i.Id == issueId);

            return issue.ToIssueResponse();
        }
    }
}
