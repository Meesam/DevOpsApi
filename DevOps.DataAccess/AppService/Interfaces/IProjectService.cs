using DevOps.Models.AppModel;
using DevOps.Models.Response;


namespace DevOps.DataAccess.AppService.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse<Project>> AddProject(Project project);
        Task<ApiResponse<Project>> UpdateProject(Project project);
        Task<ApiResponse<bool>> DeleteProject(string id);
        Task<ApiResponse<List<ProjectResponse>>> GetAllProject();
        Task<ApiResponse<Project>> GetProjectById(int Id);

    }
}
