using Entities.Account;
using Entities.ProjectEntities;
namespace Entities.JoinTables
{
    public class ApplicationUserProject
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
