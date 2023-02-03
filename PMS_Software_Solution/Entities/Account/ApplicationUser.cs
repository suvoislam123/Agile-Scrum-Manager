using Microsoft.AspNetCore.Identity;
namespace Entities.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName;
        public string LastName;
        public DateTime? DateOfBirth;
        public string UserAddress;

    }
}
