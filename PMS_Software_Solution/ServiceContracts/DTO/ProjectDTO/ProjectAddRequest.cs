using Entities.Account;
using Entities.Attributes;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Authorization;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.ProjectDTO
{
    [Authorize]
    public class ProjectAddRequest
    {
        [Required(ErrorMessage ="Please Enter Project Name")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please Enter valid Project Key")]
        [UniqueProjectKey(ErrorMessage = "This project key is taken.Try another key ")]
        public string ProjectKey { get; set; }
        [Required(ErrorMessage ="Please enter valid project catagory option")]
        public string Catagory { get; set; }
        [Required(ErrorMessage ="Please Enter valid Default Assignee")]
        public string DefaultAssignee { get; set; }
       

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
