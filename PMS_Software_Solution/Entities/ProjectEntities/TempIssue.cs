using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public class TempIssue
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public Guid BoardId { get; set; }
        public Board Board { get; set; }
       
    }
}
