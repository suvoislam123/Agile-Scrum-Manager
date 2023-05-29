using Entities.Account;
using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.JoinTables
{
    public class ApplicationUserIssue
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
