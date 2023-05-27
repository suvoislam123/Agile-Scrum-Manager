using Entities;
using Entities.Account;
using Entities.TeamEntities;
using Microsoft.AspNetCore.Identity;
using ServiceContracts.DTO;
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
            
    }
}
