using DevOps.MailService.Models;
using DevOps.MailService.Services;
using DevOpsApi.Models;
using DevOpsApi.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthenticationController:ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailService _emailService;

    
    public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUser? registerUser, string role)
    {
        if (registerUser != null)
        {
            if (registerUser.Email != null)
            {
                var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
                if (userExist != null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response {Status = "Error", Message = "User already exist"});
                }
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response {Status = "Error", Message = "User failed to create"});
                }

                await _userManager.AddToRoleAsync(user, role);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (token != null)
                {
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new {token, email=user.Email }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink);
                    _emailService.SendEmail(message);
                }
                return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = $"User created and send email to {user.Email} successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response {Status = "Error", Message = "Role does not axist"});
            }
        }
        else
        {
            return StatusCode(StatusCodes.Status403Forbidden, new Response {Status = "Error", Message = "User cannot be null"});
        }
        
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    { 
      var user = await _userManager.FindByEmailAsync(email);
      if(user != null)
      {
         var result = await _userManager.ConfirmEmailAsync(user, token);
         if(result.Succeeded)
         {
            return StatusCode(StatusCodes.Status200OK,
                 new Response { Status = "Success", Message = "Email varified successfully" });
         }  
      }
      return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Enternal error" });
    }
}