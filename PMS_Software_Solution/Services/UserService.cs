using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;

namespace Services
{
    public class UserService : IUsersService
    {
        private readonly PMS_DBContext _db;
        private readonly IUsersService _usersService;
        public UserService(PMS_DBContext db)
        {
            _db = db;
            
        }
        private UserResponse ConvertUserToUserResponse(User user)
        {
            UserResponse userResponse = user.ToUserResponse();
            return userResponse;

        }
        public UserResponse AddUser(UserAddRequest? userAddRequest)
        {
            if(userAddRequest == null)
            {
                throw new ArgumentNullException(nameof(userAddRequest));
            }
            //Model Validation
            ValidationHelper.ModelValidation(userAddRequest);
            User user = userAddRequest.ToUser();
            user.UserId = Guid.NewGuid();
            _db.Users.Add(user);
            _db.SaveChanges();
            return ConvertUserToUserResponse(user);
        }
        public List<UserResponse>  GetAllUser()
        {
            List<UserResponse> users = _db.Users.Select(country=>country.ToUserResponse()).ToList();
            return users;
        }

        
    }
}