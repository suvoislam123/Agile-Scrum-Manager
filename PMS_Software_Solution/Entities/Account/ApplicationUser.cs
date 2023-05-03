using Entities.JoinTables;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id { get; set; }
        public string FirstName;
        public string LastName;
        public DateTime? DateOfBirth;
        public string UserAddress;
        public ICollection<ApplicationUserProject>? ApplicationUserProjects { get; set;}


    }
}
