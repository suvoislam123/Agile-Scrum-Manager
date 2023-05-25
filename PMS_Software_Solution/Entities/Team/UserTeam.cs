using Entities.Account;
using Entities.JoinTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Team
{
    public class UserTeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public ICollection<ApplicationUserTeam>? ApplicationUserTeams { get; set; }
    }
}
