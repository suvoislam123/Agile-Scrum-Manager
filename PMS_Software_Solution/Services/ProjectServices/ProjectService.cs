using Entities;
using Entities.Account;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ServiceContracts;
using ServiceContracts.DTO.ProjectDTO;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly PMS_DBContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ProjectService(PMS_DBContext pMS_DBContext, SignInManager<ApplicationUser> signInManager)
        {
            _db = pMS_DBContext;
            _signInManager = _signInManager;
        }

        public Project AddProjectAsync(ProjectAddRequest? projectAddRequest, ClaimsPrincipal user)
        {
            Project project = projectAddRequest.ToProject();
            var userName = user.Identity.Name;
            project.ProjectWoner = userName;
            project.Id=Guid.NewGuid();
            Board borad = new Board()
            {
                Id=Guid.NewGuid(),
                Name="Default Board",
                Description="This is default Board for Every project",
                ProjectLead=userName,
                ProjectId=project.Id
            };
            
            project.Boards = new List<Board>() { borad};
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
  
        }

        private ProjectResponse ConvertProjectToProjectResponse(Project project)
        {
            ProjectResponse projectResponse = project.ToProjectResponse();
            return projectResponse;
        }




    }
}
