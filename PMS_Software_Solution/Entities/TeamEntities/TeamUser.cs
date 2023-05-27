using Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TeamEntities
{
    public class TeamUser
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }

        public ApplicationUser User { get; set; }
        public Team Team { get; set; }
    }
}
