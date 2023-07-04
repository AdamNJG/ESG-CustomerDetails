using ESG_Rest_Server_Application.CustomerDetails;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;

namespace ESG_Rest_Server_Test.TestDoubles
{
    internal class CustomerDetailsStorage : ICustomerDetailsStorage
    {
        public List<CustomerDetailsDto> CustomerDetails { get; private set; }

        public CustomerDetailsStorage()
        {
            CustomerDetails = new List<CustomerDetailsDto>();
        }

        public void StoreCustomerDetails(CustomerDetailsDto details)
        {
            CustomerDetails.Add(details);
        }
    }
}
