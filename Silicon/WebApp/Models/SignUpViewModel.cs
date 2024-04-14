using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Required(ErrorMessage = "You must enter a first name")]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a last name")]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email address")]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?).[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a password")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    //[RegularExpression(@"^(?=.[0-9])(?=.[a-z])(?=.[A-Z])(?=.[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    public string ConfirmPassword { get; set; } = null!;

    [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions")]
    [Display(Name = "Terms & Conditions", Prompt = "I accept the terms and conditions")]
    public bool TermsAndConditions { get; set; }
}