using Entities;
using Entities.Account;
using Entities.JoinTables;
using Entities.ProjectEntities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO.CommentDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly PMS_DBContext _pMS_DBContext;
        public CommentService(PMS_DBContext pMS_DBContext) 
        { 
            _pMS_DBContext = pMS_DBContext;
        }
        public async Task<Comment> AddComment(Guid issueId, string commentText, ApplicationUser applicationUser)
        {
            var issue = await _pMS_DBContext.Issues
                                .Include(i=>i.Comments)
                                .FirstOrDefaultAsync(i=>i.Id == issueId);

            var newComment = new Comment()
            {
                Id = Guid.NewGuid(),
                CommentText = commentText,
                CreatedDate = DateTime.Now
            };
            if(issue.Comments!= null)
            {
                issue.Comments.Add(newComment);
            }
            else
                issue.Comments = new List<Comment>() {newComment};
            var userComment = new ApplicationUserComment
            {
                ApplicationUser = applicationUser,
                Comment = newComment
            };

            _pMS_DBContext.ApplicationUserComments.Add(userComment);
            _pMS_DBContext.Comments.Add(newComment);
            await _pMS_DBContext.SaveChangesAsync();
            return newComment;
            
        }

        public async Task<List<Comment>> GetAllComments(Guid issueId)
        {

            var comments = await _pMS_DBContext.Comments
                .Include(c => c.ApplicationUserComments)
                .ThenInclude(ac => ac.ApplicationUser)
                .Where(c => c.IssueId == issueId)
                .OrderBy(c => c.CreatedDate)
                .ToListAsync();

            return comments;
            
        }

        public async Task<CommentShowResponse> getCommentDetailResponse(Comment comment)
        {
            var applicationUser = await _pMS_DBContext.ApplicationUserComments
                .Where(ac => ac.CommentId == comment.Id)
                .Select(ac => ac.ApplicationUser)
                .FirstOrDefaultAsync();


            return new CommentShowResponse()
            {
                commentText=comment.CommentText,
                CreatedAt=(DateTime)comment.CreatedDate,
                User = applicationUser
            };

        }
    }
}
