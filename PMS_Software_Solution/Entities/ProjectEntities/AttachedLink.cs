using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public  class AttachedLink
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }

    }
}
