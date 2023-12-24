using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.InputRequestModel;
using DevOps.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
       private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Route("project")]
        public async Task<IActionResult> AddProject([FromBody] ProjectInput project)
        {
             if (project == null) { return BadRequest();}
            var projectResp = await _projectService.AddProject(project);
            if (projectResp.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Project Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Create Project" });
        }

    }
}
