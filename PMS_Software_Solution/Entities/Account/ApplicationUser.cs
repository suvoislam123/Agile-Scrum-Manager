using Entities.JoinTables;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Entities.TeamEntities;

namespace Entities.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? UserAddress { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobStatus { get; set; }
        public string? Department { get; set; }
        public string? Organization { get; set; }
        public ICollection<ApplicationUserProject>? ApplicationUserProjects { get; set;}
        public ICollection<Team> Teams { get; set; }
        public ICollection<ApplicationUserIssue>? ApplicationUserIssues { get;set; } 
    }
}
