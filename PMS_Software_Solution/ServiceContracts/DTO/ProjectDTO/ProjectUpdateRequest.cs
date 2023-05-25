using Entities.Attributes;
using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.ProjectDTO
{
    public class ProjectUpdateRequest
    {   
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Please Enter Project Name")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please Enter valid Project Key")]
        [UniqueProjectKey(ErrorMessage = "This project key is taken.Try another key ")]
        public string ProjectKey { get; set; }
        [Required(ErrorMessage = "Please enter valid project catagory option")]

        public string Catagory { get; set; }
        [Required(ErrorMessage = "Please Enter valid Default Assignee")]
        public string? DefaultAssignee { get; set; }

        public string? ProjectWoner { get; set; }
        public string? ProjectLead { get; set; }


        public Project ToProject()
        {
            return new Project()
            {
                ProjectName = ProjectName,
                ProjectKey = ProjectKey,
                Catagory = Catagory,
                DefaultAssignee = DefaultAssignee,
            };
        }
        
    }
}
