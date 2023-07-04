using ESG_Console_Parser.Customer;

namespace ESG_Console_Parser.Ports
{
    public interface ICustomerSender
    {
        public Task SendCustomerDetails(CustomerDetailsDto data);
    }
}
