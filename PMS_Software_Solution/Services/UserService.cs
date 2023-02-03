using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.AspNetCore.Identity;
using Entities.Account;

namespace Services
{
    public class UserService : IUsersService
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(User user)
        {
            var newUser =new ApplicationUser()
            {
                Email= user.Email,
                UserName= user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth= user.DateOfBirth,
                UserAddress = user.UserAddress
                

            };
            var result = await _userManager.CreateAsync(newUser, user.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInUser signInUser)
        {
           var result = await _signInManager.PasswordSignInAsync(signInUser.UserName, signInUser.Password, signInUser.RememberMe, false);
           return result;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}