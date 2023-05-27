using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.AspNetCore.Identity;
using Entities.Account;
using Microsoft.EntityFrameworkCore;
using Entities.TeamEntities;

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

        public async Task<List<ApplicationUser>> GetApplicationUsersByTeamId(int teamId)
        {
            var users = await _pMS_DBcontext.Teams
                    .Where(t => t.Id == teamId)
                    .SelectMany(t => t.Users)
                    .ToListAsync();

            return users;
        }

        public async Task<List<Team>> GetTeamsByUserId(string userId)
        {
            var teams = await _pMS_DBcontext.Teams
            .Where(t => t.Users.Any(u => u.Id == userId))
            .ToListAsync();
            return teams;
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