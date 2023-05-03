using Entities.Account;
using Entities.ProjectEntities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.ProjectDTO
{
    public class ProjectAddRequest
    {
        [Required(ErrorMessage ="Please Enter Project Name")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please Enter valid Project Key")]
        public string ProjectKey { get; set; }
        [Required(ErrorMessage ="Please enter valid project catagory option")]
        public string Catagory { get; set; }
        [Required(ErrorMessage ="Please Enter valid Default Assignee")]
        public string DefaultAssignee { get; set; }
        public string Id { get; set; }
        public string? ProjectWoner { get; set; }

        public Project ToProject()
        {
            return new Project()
            {
                ProjectName= ProjectName,
                ProjectKey= ProjectKey,
                Catagory= Catagory,
                DefaultAssignee= DefaultAssignee,
            };
        }
    }
}
