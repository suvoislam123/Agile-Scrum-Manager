using Entities.ProjectEntities;
using ServiceContracts.DTO.ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IProjectService
    {
        Project AddProjectAsync(ProjectAddRequest? projectAddRequest, ClaimsPrincipal user);
        // List<ProjectResponse> GetAllProjectByOwnerUserName(string UserName);
        Task<List<ProjectResponse>> GetProjectsByWoner(ClaimsPrincipal user);
        Task<ProjectResponse> DeleteProjectAsync(Guid id);
        Task<ProjectResponse> GetProjectByIdAsync(Guid id);
        Task<ProjectResponse> UpdateProjectByIdAsync(ProjectUpdateRequest projectUpdateRequest);
        Task<Project> LaunchProject(Guid projectId);

    }
}
