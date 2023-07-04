using ESG_Console_Parser.Customer;
using ESG_Console_Parser.Ports;

namespace ESG_Console_Parser_Test.TestDoubles
{
    internal class TestCustomerSender : ICustomerSender
    {
        public List<CustomerData> Customers { get; private set; }

        public TestCustomerSender()
        {
            Customers = new List<CustomerData>();
        }

        public Task SendCustomerData(CustomerData data)
        {
            Customers.Add(data);
            return Task.CompletedTask;
        }
    }
}
