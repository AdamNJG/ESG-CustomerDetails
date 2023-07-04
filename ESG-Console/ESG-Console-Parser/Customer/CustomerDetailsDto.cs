namespace ESG_Console_Parser.Customer
{
    public class CustomerDetailsDto
    {
        public string CustomerRef { get; private set; }
        public string CustomerName { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string Town { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        public string PostCode { get; private set; }

        public CustomerDetailsDto(string customerRef, string customerName, string addressLine1, string addressLine2, string town, string county, string country, string postCode)
        {
            CustomerRef = customerRef;
            CustomerName = customerName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Town = town;
            County = county;
            Country = country;
            PostCode = postCode;
        }
    }
}

