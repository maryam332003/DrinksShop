using System.ComponentModel.DataAnnotations;

namespace DrinkAndGo.PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName Name Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password Length Is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not Match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
