using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ecom.minhhai.bookstore.ViewModel
{
    public class RegisterViewModel
    {
        public Guid CustomerId { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage ="Please enter your name!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email!")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Remote(action: "ValidateEmail", controller: "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone!")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Remote(action: "ValidatePhone", controller: "Account")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Plese enter your password")]
        [MinLength(5, ErrorMessage = "You need to set a password of at least 5 characters!")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password")]
        [MinLength(5, ErrorMessage = "You need to set a password of at least 5 characters!")]
        [Compare("Password", ErrorMessage = "The passwords you entered do not match, please re-enter")]
        public string ConfirmPassword { get; set; }
    }
}
