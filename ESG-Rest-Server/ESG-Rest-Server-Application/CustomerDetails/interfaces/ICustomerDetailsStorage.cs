using ESG_Rest_Server_Application.CustomerDetails.Dto;

namespace ESG_Rest_Server_Application.CustomerDetails.interfaces
{
    public interface ICustomerDetailsStorage
    {

        public void StoreCustomerDetails(CustomerDetailsOutDto details);

        public Task<CustomerDetailsOutDto> GetCustomer(Guid customerId);
    }
}
