using Entities.ProjectEntities;
using ServiceContracts.DTO.IssueDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IIssueService
    {
        public Task<IssueReponse> GetIssueByIssueId(Guid issueId);
        public Task<Comment> AddComment(Guid issueId, string CommentText,string userName);
    }
}
