using Entities.Account;
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
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
        public string CommentedBy { get; set; }
        
    }
}
