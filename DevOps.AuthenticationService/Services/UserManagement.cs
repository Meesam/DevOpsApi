﻿using DevOps.MailService.Services;
using DevOps.Models.Authentication.SignUp;
using DevOps.Models.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DevOps.AuthenticationService.Services
{
    public class UserManagement : IUserManagement
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;


        public UserManagement(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<ApiResponse<List<string>>> AssignRoleToUserAsync(IEnumerable<string> roles, IdentityUser user)
        {
            var assignedRole = new List<string>();
            foreach(var role in roles) 
            {
              if (await _roleManager.RoleExistsAsync(role))
              {
                 if (!await _userManager.IsInRoleAsync(user, role))
                 {
                    await _userManager.AddToRoleAsync(user, role);
                        assignedRole.Add(role);
                 }
              }
            }

            return new ApiResponse<List<string>> { IsSuccess = true, StatusCode = 200, Message = "Roles has been assign", Response = assignedRole };
        }

        public async Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser)
        {
            if (registerUser != null)
            {
                if (registerUser.Email != null)
                {
                    var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
                    if (userExist != null)
                    {
                        return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User already exist" };                                                                                      
                    }
                }

                IdentityUser user = new()
                {
                    Email = registerUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerUser.UserName
                };

                if (await _roleManager.RoleExistsAsync(registerUser.Role))
                {
                    var result = await _userManager.CreateAsync(user, registerUser.Password);
                    if (!result.Succeeded)
                    {
                        return new ApiResponse<string> { IsSuccess = false, StatusCode = 500, Message = "User failed to create" };
                    }

                    await _userManager.AddToRoleAsync(user, registerUser.Role);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                   
                    return new ApiResponse<string> { IsSuccess = true, StatusCode = 200, Message = "User created successfully", Response = token };
                }
                else
                {
                    return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "Role does not axist" };
                }
            }
            else
            {
                return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User cannot be null" };
            }
        }
    }
}
