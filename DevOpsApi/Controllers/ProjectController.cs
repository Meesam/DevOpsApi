using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
             if (project == null) { return BadRequest();}
            var projectResp = await _projectService.AddProject(project);
            if (projectResp.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Project Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Create Project" });
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProject()
        {
            var projectResp = await _projectService.GetAllProject();
            if (projectResp.IsSuccess)
            {
              return Ok(projectResp);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to get all projects" });
        }

    }
}
