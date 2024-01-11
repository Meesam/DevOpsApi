using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.Response;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ApiResponse<Project>> AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            SaveChanges();
            return new ApiResponse<Project> { StatusCode = 200, IsSuccess = true, Message = "Project added successfully", Response = null };
        }

        public Task<ApiResponse<bool>> DeleteProject(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<ProjectResponse>>> GetAllProject()
        {
            var projects = from project in _context.Projects
                           join customer in _context.Customers on project.CustomerId equals customer.Id
                           select new ProjectResponse
                           {
                               ProjectId = project.Id,
                               CustomerId = customer.Id,
                               CustomerName = customer.Name  ?? "NA",
                               ProjectName = project.Name ?? "NA",
                               ProjectDescription = project.Description ?? "NA" ,
                               ProjectType = project.ProjectType ?? "NA",
                               ProjectStartDate = project.ProjectStartDate,
                               ProjectEndDate = project.ProjectEndDate,
                               ProjectStatus = project.ProjectStatus ?? "NA",
                           };
            var allProjects = await  projects.ToListAsync();
            return new ApiResponse<List<ProjectResponse>> { IsSuccess = true, Message = "Project List", StatusCode = 200, Response = allProjects };

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
