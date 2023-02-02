
using Entities;
namespace ServiceContracts.DTO
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserAddress { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(UserResponse)) return false;
            UserResponse user = (UserResponse)obj;
            return UserId == user.UserId && FirstName == user.FirstName && LastName == user.LastName && PhoneNumber == user.PhoneNumber && Email == user.Email && UserName == user.UserName && UserAddress == user.UserAddress;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public static class UserExtensions
    {
        public static UserResponse ToUserResponse(this User user)
        {
            return new UserResponse { UserId = user.UserId, FirstName = user.FirstName, Email = user.Email, PhoneNumber = user.PhoneNumber, UserName = user.UserName, UserAddress = user.UserAddress };
        }
    }
}
