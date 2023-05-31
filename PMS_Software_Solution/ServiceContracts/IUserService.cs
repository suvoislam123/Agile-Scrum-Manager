using Entities;
using Entities.Account;
using Entities.ProjectEntities;
using Entities.TeamEntities;
using Microsoft.AspNetCore.Identity;
using ServiceContracts.DTO;
using ServiceContracts.DTO.ProjectDTO;

namespace ServiceContracts
{
    public interface IUsersService
    {
        Task<IdentityResult> CreateUserAsync(User user);
        Task<SignInResult> PasswordSignInAsync(SignInUser signInUser);
        Task SignOutAsync();
        Task<ApplicationUser> GetUserByUserName(string userName);
        Task<List<Team>> GetTeamsByUserId(string userId);
        Task<List<ApplicationUser>> GetApplicationUsersByTeamId(int teamId);
        Task<ApplicationUser> GetApplicationUserById(string id);
        Task<Team> GetTeamById(int teamId);
        Task<List<Team>> GetTeamsCreatedByMe(ApplicationUser applicationUser);
        Task<Project> EnrollProjectByProjectKey(string projectKey,string userName);
            
    }
}
