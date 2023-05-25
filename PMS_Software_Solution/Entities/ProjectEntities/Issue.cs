using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public  class Issue
    {
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public Guid SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public string? IssueTye { get;set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<AttachedFile>? AttachedFiles { get; set; }
        public ICollection<AttachedLink>? AttachedLinks { get; set; }
        
    }
}
