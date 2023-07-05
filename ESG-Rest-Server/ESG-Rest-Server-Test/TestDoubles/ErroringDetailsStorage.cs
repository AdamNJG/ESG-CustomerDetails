using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESG_Rest_Server_Test.TestDoubles
{
    internal class ErroringDetailsStorage : ICustomerDetailsStorage
    {
        public Task<CustomerDetailsOutDto> GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void StoreCustomerDetails(CustomerDetailsOutDto details)
        {
            throw new DbUpdateException();
        }
    }
}
