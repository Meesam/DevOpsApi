using DevOps.Models.Authentication.SignUp;
using DevOps.Models.Response;

namespace DevOps.AuthenticationService.Services
{
    public interface IUserManagement
    {
        Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser);
    }
}
