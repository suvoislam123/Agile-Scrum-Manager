using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage ="Please Enter your first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter your last name")]
        [Display(Name = "Last Name")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter your email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Chose a valid Email Address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Chose a user name")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Chose a Passoword")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Chose a password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Your Address ")]
        [Display(Name = "Your Address")]
        public string? UserAddress { get; set; }

    }
}