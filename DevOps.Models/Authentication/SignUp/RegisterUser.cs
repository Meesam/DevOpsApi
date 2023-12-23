using System.ComponentModel.DataAnnotations;

namespace DevOps.Models.Authentication.SignUp;

public class RegisterUser
{
    [Required(ErrorMessage = "User name is required")]
    public string? UserName { get; set; }
    
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public string? Role { get; set; }
}