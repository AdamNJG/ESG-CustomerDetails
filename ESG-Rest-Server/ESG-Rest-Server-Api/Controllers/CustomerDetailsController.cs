using ESG_Rest_Server_Application.CustomerDetails;
using ESG_Rest_Server_Application.CustomerDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ESG_Rest_Server_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly CustomerDetailsService _customerDetailsService;

        public CustomerDetailsController(CustomerDetailsService customerDetailsService)
        {
            _customerDetailsService = customerDetailsService;
        }

        [HttpPost("AddCustomers")]
        public IActionResult AddCustomers([FromBody] CustomerDetailsInDto details)
        {
            _customerDetailsService.StoreCustomerDetails(details);

            return Ok();
        }

        [HttpGet("GetCustomer/{customerRef}")]
        public async Task<ActionResult<CustomerDetailsOutDto>> GetCustomerDetails([FromRoute] Guid customerRef)
        {
            CustomerDetailsOutDto result = await _customerDetailsService.GetCustomerDetails(customerRef);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}