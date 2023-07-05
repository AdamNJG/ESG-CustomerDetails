using ESG_Rest_Server_Application.CustomerDetails.Dto;
using System.Text.RegularExpressions;

namespace ESG_Rest_Server_Application.CustomerDetails.Domain
{
    public class CustomerData
    {
        private readonly Guid CustomerRef;
        private readonly string CustomerName;
        private readonly string AddressLine1;
        private readonly string AddressLine2;
        private readonly string Town;
        private readonly string County;
        private readonly string Country;
        private readonly string PostCode;

        public CustomerData(CustomerDetailsInDto inDto)
        {
            CustomerRef = ParseCustomerRef(inDto.CustomerRef);
            CustomerName = inDto.CustomerName;
            AddressLine1 = inDto.AddressLine1;
            AddressLine2 = inDto.AddressLine2;
            Town = inDto.Town;
            County = inDto.County;
            Country = inDto.Country;
            PostCode = CheckPostCode(inDto.PostCode);
        }

        public CustomerDetailsOutDto GetDto()
        {
            return new CustomerDetailsOutDto()
            {
                CustomerRef = this.CustomerRef,
                CustomerName = this.CustomerName,
                AddressLine1 = this.AddressLine1,
                AddressLine2 = this.AddressLine2,
                Town = this.Town,
                County = this.County,
                Country = this.Country,
                PostCode = this.PostCode
            };
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
