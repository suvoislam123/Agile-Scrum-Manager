using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.IssueDTO
{
    public class IssueReponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public Guid SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public string? IssueTye { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
    public static class IssueResponseExtension
    {
        public static IssueReponse ToIssueResponse(this Issue issue)
        {
            return new IssueReponse()
            {
                Id = issue.Id,
                Name = issue.Name,
                Description = issue.Description,
                State = issue.State,
                Priority = issue.Priority,
                SprintId = issue.SprintId,
                IssueTye = issue.IssueTye,
                Comments = issue.Comments,

            };
        }
    }
}
