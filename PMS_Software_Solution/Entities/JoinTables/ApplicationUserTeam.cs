using Entities.Account;
using Entities.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.JoinTables
{
    public class ApplicationUserTeam
    {
        public string ApplicationUserId { get;set; }
        public ApplicationUser ApplicationUser { get;set; }
        public Guid UserTeamId { get;set; }
        public UserTeam UserTeam { get;set; }
        ICollection<ApplicationUserTeam>? ApplicationUserTeams { get; set; }
    }
}
