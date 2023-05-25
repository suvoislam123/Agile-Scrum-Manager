using Entities.Account;
using Entities.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.ProjectDTO
{
    public class ProjectResponse
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
        public string Catagory { get; set; }
        public string DefaultAssignee { get; set; }
        public string ProjectWoner { get;set; }
        public string ProjectLead { get;set; }
        public string ProjectLeadEmail { get; set; }
        public Project ToProject()
        {
            return new Project()
            {
                Id  = Id,
                ProjectName = ProjectName,
                ProjectKey = ProjectKey,
                Catagory = Catagory,
                DefaultAssignee = DefaultAssignee,
                ProjectWoner = ProjectWoner,
                ProjectLead = ProjectLead,

            };
        }
        
    }
    public static class ProjectExtensions
    {
        public static ProjectResponse ToProjectResponse(this Project project)
        {
            return new ProjectResponse()
            {
                Id=project.Id,
                ProjectName = project.ProjectName,
                ProjectKey = project.ProjectKey,
                Catagory = project.Catagory,
                DefaultAssignee= project.DefaultAssignee,
                ProjectWoner = project.ProjectWoner,
                ProjectLead = project.ProjectLead
                //ProjectLead = project.ProjectLeadEmail,
            };
        }
    }
    public static class ProjectUpdateRequestResponse
    {
        public static ProjectUpdateRequest ToProjectUpdateRequest(this ProjectResponse projectResponse)
        {
            return new ProjectUpdateRequest()
            {
                Id = projectResponse.Id,
                ProjectName = projectResponse.ProjectName,
                ProjectKey = projectResponse.ProjectKey,
                Catagory = projectResponse.Catagory,
                DefaultAssignee = projectResponse.DefaultAssignee,
                ProjectWoner = projectResponse.ProjectWoner,
                ProjectLead = projectResponse.ProjectLead
                //ProjectLead = project.ProjectLeadEmail,
            };
        }
    }
}
