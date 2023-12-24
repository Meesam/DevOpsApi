using DevOps.Models.AppModel;
using DevOps.Models.InputRequestModel;
using DevOps.Models.Response;


namespace DevOps.DataAccess.AppService.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse<Project>> AddProject(ProjectInput project);
        Task<ApiResponse<Project>> UpdateProject(Project project);
        Task<ApiResponse<bool>> DeleteProject(string id);
        Task<ApiResponse<IQueryable<Project>>> GetAllProject();
        Task<ApiResponse<Project>> GetProjectById(int Id);

    }
}
