using Entities.Account;
using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.JoinTables
{
    public  class ApplicationUserComment    
    {
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        public string ApplicationUserId { get; set;}
        public ApplicationUser ApplicationUser { get; set;}

    }
}
