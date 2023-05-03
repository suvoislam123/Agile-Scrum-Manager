using Entities.Account;
using Entities.JoinTables;
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
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
        public string Catagory { get; set; }
        public string DefaultAssignee { get; set; }
        public string? ProjectWoner { get; set; }
        public ICollection<Board>? Boards { get; set; }
        public ICollection<ApplicationUserProject>? ApplicationUserProjects { get; set; }

    }
}
