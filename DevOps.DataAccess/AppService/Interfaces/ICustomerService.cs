using DevOps.Models.AppModel;
using DevOps.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.DataAccess.AppService.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<Customer>> AddCustomer(Customer customer);
        Task<ApiResponse<Customer>> UpdateCustomer(Project project);
        Task<ApiResponse<bool>> DeleteCustomer(string id);
        Task<ApiResponse<List<Customer>>> GetAllCustomer();
        Task<ApiResponse<Customer>> GetCustomerById(int Id);
    }
}
