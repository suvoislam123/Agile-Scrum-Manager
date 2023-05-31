using Entities.Account;
using Entities.ProjectEntities;
using ServiceContracts.DTO.CommentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICommentService
    {
        Task<Comment> AddComment(Guid issueId, string commentText,ApplicationUser applicationUser);
        Task<List<Comment>> GetAllComments(Guid issueId);
        Task<CommentShowResponse> getCommentDetailResponse(Comment comment);
    }
}
