using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.BoardDTO
{
    public class BacklogAddRequest
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage ="Please describe the issue. What is need to be done")]
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public string? IssueType { get;set; }
        public Guid? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? BoardId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<AttachedFile>? AttachedFiles { get; set; }
        public ICollection<AttachedLink>? AttachedLinks { get; set; }
        public Issue ToIssue()
        {
            return new Issue()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                IssueTye= IssueType,
                State = State,
                Priority = Priority,
                SprintId= SprintId.HasValue ? SprintId.Value : Guid.Empty
            };
        }
        public TempIssue ToTempIssue()
        {
            return new TempIssue()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                State = State,
                Priority = Priority,
                BoardId = BoardId.HasValue ? BoardId.Value : Guid.Empty
            };
        }
    }
}
