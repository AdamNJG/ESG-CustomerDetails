using ESG_Rest_Server_Application.CustomerDetails;
using Microsoft.AspNetCore.Mvc;

namespace ESG_Rest_Server_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerDetailsController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;

        /*public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/

        [HttpPost("AddCustomers")]
        public IActionResult AddCustomers([FromBody] CustomerDetailsDto details)
        {
            Console.WriteLine(details);

            return Ok();
        }
    }
}