using ESG_Rest_Server_Application.CustomerDetails;
using ESG_Rest_Server_Application.CustomerDetails.Domain;
using ESG_Rest_Server_Application.CustomerDetails.Dto;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Add customer details.
        /// </summary>
        /// <param name="details">The customer details.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost("AddCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCustomers([FromBody] CustomerDetailsInDto details)
        {
            CreateResult result = _customerDetailsService.StoreCustomerDetails(details);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Get customer details by customer reference.
        /// </summary>
        /// <param name="customerRef">The customer reference.</param>
        /// <returns>The customer details.</returns>
        [HttpGet("GetCustomer/{customerRef}")]
        [ProducesResponseType(typeof(CustomerDetailsOutDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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