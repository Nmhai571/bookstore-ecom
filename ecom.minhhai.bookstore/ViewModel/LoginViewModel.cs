using System.ComponentModel.DataAnnotations;

namespace ecom.minhhai.bookstore.ViewModel
{
    public class LoginViewModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "You need to set a password of at least 5 characters!")]
        public string Password { get; set; }

    }
}
