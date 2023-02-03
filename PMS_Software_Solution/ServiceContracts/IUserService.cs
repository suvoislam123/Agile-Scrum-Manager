using Entities;
using Entities.Account;
using Microsoft.AspNetCore.Identity;
using ServiceContracts.DTO;
namespace ServiceContracts
{
    public interface IUsersService
    {
        Task<IdentityResult> CreateUserAsync(User user);
        Task<SignInResult> PasswordSignInAsync(SignInUser signInUser);
        Task SignOutAsync();
            
    }
}
