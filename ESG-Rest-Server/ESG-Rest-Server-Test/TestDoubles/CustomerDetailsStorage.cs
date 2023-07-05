using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESG_Rest_Server_Test.TestDoubles
{
    internal class CustomerDetailsStorage : ICustomerDetailsStorage
    {
        public List<CustomerDetailsOutDto> CustomerDetails { get; private set; }

        public CustomerDetailsStorage()
        {
            CustomerDetails = new List<CustomerDetailsOutDto>();
        }

        public void StoreCustomerDetails(CustomerDetailsOutDto details)
        {
            CustomerDetails.Add(details);
        }

        public Task<CustomerDetailsOutDto> GetCustomer(Guid customerId)
        {
            CustomerDetailsOutDto dto = CustomerDetails.FirstOrDefault(d => d.CustomerRef == customerId);

            if (dto == null)
            {
                throw new DbUpdateException();
            }

            return Task.FromResult(dto);
        }
    }
}
