using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    [HttpGet("employees")]
    public IEnumerable<string> GetEmployees()
    {
        return new List<string> { "emp-1", "emp-2", "emp-3" };
    }
}
