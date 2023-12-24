using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.InputRequestModel;
using DevOps.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.DataAccess.AppService.Implementation
{
    public class ProjectService : IProjectService
    {
        
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<Project>> AddProject(ProjectInput project)
        {
            await _context.Projects.AddAsync(project);
            SaveChanges();
            return new ApiResponse<Project> { StatusCode = 200, IsSuccess = true, Message = "Project added successfully", Response = null };
        }

        public Task<ApiResponse<bool>> DeleteProject(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IQueryable<Project>>> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Project>> GetProjectById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Project>> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
