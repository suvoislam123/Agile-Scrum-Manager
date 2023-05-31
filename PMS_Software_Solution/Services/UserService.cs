using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using Microsoft.AspNetCore.Identity;
using Entities.Account;
using Microsoft.EntityFrameworkCore;
using Entities.TeamEntities;
using ServiceContracts.DTO.ProjectDTO;
using Entities.ProjectEntities;
using Entities.JoinTables;

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

        public async Task<Project> EnrollProjectByProjectKey(string projectKey,string userName)
        {
            var user = await _pMS_DBcontext.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName == userName);
            Project project =await  _pMS_DBcontext.Projects
                .Include(p=>p.ApplicationUserProjects)
                .Include(b=>b.Boards)
                .FirstOrDefaultAsync(p => p.ProjectKey == projectKey);
            if(project!= null)
            {
                var userProject = new ApplicationUserProject()
                {
                    ApplicationUser = user,
                    Project = project
                };
                if(project.ApplicationUserProjects!=null)
                    if(!_pMS_DBcontext.ApplicationUserProjects.Contains(userProject))
                        _pMS_DBcontext.ApplicationUserProjects.Add(userProject);
                await _pMS_DBcontext.SaveChangesAsync();
            }
            return project;
        }

        public async Task<ApplicationUser> GetApplicationUserById(string id)
        {
            var user = await _pMS_DBcontext.ApplicationUsers.FindAsync(id);
            return user;
        }

        public async Task<List<ApplicationUser>> GetApplicationUsersByTeamId(int teamId)
        {
            var users = await _pMS_DBcontext.Teams
                    .Where(t => t.Id == teamId)
                    .SelectMany(t => t.Users)
                    .ToListAsync();

            return users;
        }

        public async Task<Team> GetTeamById(int teamId)
        {
            var team = await _pMS_DBcontext.Teams.Include(t => t.Users)
                        .FirstOrDefaultAsync(t=>t.Id==teamId);
            return team;           
        }

        public async Task<List<Team>> GetTeamsByUserId(string userId)
        {
            var teams = await _pMS_DBcontext.Teams
            .Where(t => t.Users.Any(u => u.Id == userId))
            .ToListAsync();
            return teams;
        }

        public async Task<List<Team>> GetTeamsCreatedByMe(ApplicationUser applicationUser)
        {
            var teams = await _pMS_DBcontext.Teams
            .Where(t => t.Users.Any(u => u.Id == applicationUser.Id) && t.AdminUserName==applicationUser.UserName)
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