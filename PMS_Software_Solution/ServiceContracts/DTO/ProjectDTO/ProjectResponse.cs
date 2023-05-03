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
    }
    public static class ProjectExtensions
    {
        public static ProjectResponse ToProjectResponse(this Project project)
        {
            return new ProjectResponse()
            {
                Id  = project.Id,
                ProjectName = project.ProjectName,
                ProjectKey = project.ProjectKey,
                Catagory = project.Catagory,
                DefaultAssignee= project.DefaultAssignee
            };
        }
    }
}
