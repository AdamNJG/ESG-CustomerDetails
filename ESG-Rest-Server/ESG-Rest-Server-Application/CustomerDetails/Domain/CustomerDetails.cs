using System.Text.RegularExpressions;

namespace ESG_Rest_Server_Application.CustomerDetails.Domain
{
    public class CustomerDetails
    {
        public Guid CustomerRef { get; private set; }
        public string CustomerName { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string Town { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        public string PostCode { get; private set; }

        public CustomerDetails(string customerRef, string customerName, string addressLine1, string addressLine2, string town, string county, string country, string postCode)
        {
            CustomerRef = ParseCustomerRef(customerRef);
            CustomerName = customerName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Town = town;
            County = county;
            Country = country;
            PostCode = CheckPostCode(postCode);
        }

        private Guid ParseCustomerRef(string customerRef)
        {
            if (Guid.TryParse(customerRef, out Guid guid))
            {
                return guid;
            }
            throw new ArgumentException($"CustomerRef is not a valid UUID: {customerRef}");
        }

        private string CheckPostCode(string postCode)
        {
            if (Regex.IsMatch(postCode, @"^[A-Za-z]{1,2}[0-9Rr][0-9A-Za-z]? [0-9][A-Za-z]{2}$"))
            {
                return postCode;
            }
            throw new ArgumentException($"PostCode for customer {this.CustomerRef} is not valid: {postCode}");
        }
    }
}
