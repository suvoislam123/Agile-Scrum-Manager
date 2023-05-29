using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.SprintDTO
{
    public class SprintUpdateRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please Give a Sprint Name")]
        public string? Name { get;set; }
        [Required(ErrorMessage ="Please select Start Date")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage ="Please Give a Sprint Goal")]
        public string? SprintGoal { get; set; }
        public bool? IsActive { get; set; }
        [Required(ErrorMessage = "Please select End Date Date")]
        public DateTime? EndDate { get; set; }
        public Guid? BoardId { get; set; }
    }
}
