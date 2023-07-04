using ESG_Console_Parser.Customer;
using ESG_Console_Parser.Ports;

namespace ESG_Console_Parser_Test.TestDoubles
{
    internal class TestCustomerSender : ICustomerSender
    {
        public List<CustomerDetailsDto> Customers { get; private set; }

        public TestCustomerSender()
        {
            Customers = new List<CustomerDetailsDto>();
        }

        public Task SendCustomerDetails(CustomerDetailsDto data)
        {
            Customers.Add(data);
            return Task.CompletedTask;
        }
    }
}
