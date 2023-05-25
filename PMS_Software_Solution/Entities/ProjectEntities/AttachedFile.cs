using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public class AttachedFile
    {
        public Guid Id {  get; set; }   
        public string? Path { get; set; }
        public string? FileType { get; set; }
        public Guid IssueId { get; set; }   
        public Issue? Issue { get; set; }

    }
}
