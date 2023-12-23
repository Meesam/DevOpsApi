using DevOps.Models.Authentication.SignUp;
using DevOps.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace DevOps.AuthenticationService.Services
{
    public interface IUserManagement
    {
        Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser);
        Task<ApiResponse<List<string>>> AssignRoleToUserAsync(IEnumerable<string> roles, IdentityUser user);
    }
}
