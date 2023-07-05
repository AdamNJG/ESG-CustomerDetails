using ESG_Rest_Server_Application.CustomerDetails.Domain;
using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;
using Microsoft.Extensions.Logging;

namespace ESG_Rest_Server_Application.CustomerDetails
{
    public class CustomerDetailsService
    {
        private readonly ICustomerDetailsStorage _customerDetailsStorage;
        private readonly ILogger<CustomerDetailsService> _logger;

        public CustomerDetailsService(ICustomerDetailsStorage customerDetailsStorage, ILogger<CustomerDetailsService> logger)
        {
            _customerDetailsStorage = customerDetailsStorage;
            _logger = logger;
        }

        public void StoreCustomerDetails(CustomerDetailsInDto inputDetails)
        {
            try
            {
                CustomerData details = new CustomerData(inputDetails);
                _customerDetailsStorage.StoreCustomerDetails(details.GetDto());
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public async Task<CustomerDetailsOutDto> GetCustomerDetails(Guid customerId)
        {
            try
            {
                return await _customerDetailsStorage.GetCustomer(customerId);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }
    }
}
