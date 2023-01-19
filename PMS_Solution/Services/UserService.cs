using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class UserService : IUsersService
    {
        private readonly PMS_DBContext _db;
        private readonly IUsersService _usersService;
        public UserService(PMS_DBContext db, IUsersService usersService)
        {
            _db = db;
            _usersService = usersService;
        }
        private UserResponse ConvertUserToUserResponse(User user)
        {
            UserResponse userResponse = user.ToUserResponse();
            return userResponse;

        }
        public UserResponse AddUser(UserAddRequest? userAddRequest)
        {
            User user = userAddRequest.ToUser();
            user.UserId = Guid.NewGuid();
            _db.Users.Add(user);
            _db.SaveChanges();
            return ConvertUserToUserResponse(user);
        }
    }
}