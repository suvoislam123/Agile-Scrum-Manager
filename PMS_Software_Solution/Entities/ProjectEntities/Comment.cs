using Entities.Account;
using Entities.JoinTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public  class Comment
    {
        public Guid Id { get; set; }
        public string? CommentText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
        public ICollection<ApplicationUserComment>? ApplicationUserComments { get; set; }    
        
    }
}
