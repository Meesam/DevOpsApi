using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.InputRequestModel;
using DevOps.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null) { return BadRequest(); }
            var customerResp = await _customerService.AddCustomer(customer);
            if (customerResp.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Customer Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Create Customer" });
        }

        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var allCustomers = await _customerService.GetAllCustomer();
            if (allCustomers.IsSuccess)
            {
                return Ok(allCustomers);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to get all Customer" });
        }

        [HttpPost]
        [Route("addCustomerContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCustomerWithContacts([FromBody] CustomerInputModel customerInputModel)
        {
            if (customerInputModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Failed to get all Customer" });
            }
            else
            {
              var resp = await _customerService.AddCustomerWithContacts(customerInputModel);
              if (resp.IsSuccess)
              {
                 return Ok(resp);
              }
             
             return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Create Customer" });
                
            }
        }
    }
}
