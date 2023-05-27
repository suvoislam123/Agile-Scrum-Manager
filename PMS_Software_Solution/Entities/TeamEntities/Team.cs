using Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TeamEntities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? AdminUserName { get; set; }
        public int? TotalUsers { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
