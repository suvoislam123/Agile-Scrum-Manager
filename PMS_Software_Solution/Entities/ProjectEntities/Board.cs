﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProjectEntities
{
    public class Board
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectLead { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Sprint> Sprints { get; set; }
    }
}