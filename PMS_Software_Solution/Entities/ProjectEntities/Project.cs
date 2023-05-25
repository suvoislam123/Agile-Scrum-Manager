using Entities.Account;
using Entities.Attributes;
using Entities.JoinTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.ProjectEntities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public string? ProjectName { get; set; }
        [UniqueProjectKey(ErrorMessage ="This project key is taken.Try another key ")]
        public string ProjectKey { get; set; }
        public string? Catagory { get; set; }
        public string? DefaultAssignee { get; set; }
        public string? ProjectWoner { get; set; }
        public DateTime? LastVisitedTime { get; set; }

        //public string? ProjectWonerEmail { get;set; }
        public string? ProjectLead { get; set; }
        //public string? ProjectLeadEmail { get; set; }
        public ICollection<Board>? Boards { get; set; }
        public ICollection<ApplicationUserProject>? ApplicationUserProjects { get; set; }

    }
}
