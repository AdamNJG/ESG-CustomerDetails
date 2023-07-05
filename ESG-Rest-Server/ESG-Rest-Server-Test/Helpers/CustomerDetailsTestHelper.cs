using ESG_Rest_Server_Application.CustomerDetails.Dto;

namespace ESG_Rest_Server_Test.Helpers
{
    static class CustomerDetailsTestHelper
    {
        public static CustomerDetailsInDto CreateTestCustomerData()
        {
            return new CustomerDetailsInDto()
            {
                CustomerRef = Guid.NewGuid().ToString(),
                CustomerName = "John Smith",
                AddressLine1 = "1 Main Street",
                AddressLine2 = string.Empty,
                Town = "London",
                County = "Greater London",
                Country = "United Kingdom",
                PostCode = "E1 7PT"
            };
        }
    }
}
