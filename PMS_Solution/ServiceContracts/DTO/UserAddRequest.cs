using Entities;
namespace ServiceContracts.DTO
{
    public class UserAddRequest
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserAddress { get; set; }
        public User ToUser()
        {
            return new User { FirstName = FirstName, LastName = LastName, PhoneNumber = PhoneNumber, Email = Email, UserName = UserName, UserAddress = UserAddress };
        }
    }
}
