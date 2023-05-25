using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.BoardDTO
{
    public class BoardAddRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please Enter a BoardName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Board Description")]
        public string? Description { get; set; }
        public string? ProjectLead { get; set; }
        public DateTime? LastVistedTime { get; set; }
        public Guid ProjectId { get; set; }
        public Board ToBoard()
        {
            return new Board()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                ProjectLead = ProjectLead,
                LastVistedTime = DateTime.Now,
                ProjectId = ProjectId
            };
        }
    }
}
