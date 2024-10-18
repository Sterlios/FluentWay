using System.ComponentModel.DataAnnotations;

namespace FluentWay.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public required string ConfirmPassword { get; set; }
    }
}
