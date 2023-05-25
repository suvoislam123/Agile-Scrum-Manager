using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.AspNetCore.Identity;
using Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserService : IUsersService
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly PMS_DBContext _pMS_DBcontext;
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,PMS_DBContext pMS_DBcontext) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _pMS_DBcontext = pMS_DBcontext;
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

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await _pMS_DBcontext.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName == userName);
            return user;
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