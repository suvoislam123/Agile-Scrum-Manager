using Entities.ProjectEntities;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
namespace PMS_Software.ViewModels
{
    public class CommentViewModel
    {
        public Guid IssueId { get; set; }
        
        public ICollection<Comment>? Comments { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage="Please Enter a comment")]
        public string CommentText { get; set; }
        public IssueViewModel? IssueViewModel { get; set; }
    }
}
