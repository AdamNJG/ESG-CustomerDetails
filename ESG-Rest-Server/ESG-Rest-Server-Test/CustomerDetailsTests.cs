using ESG_Rest_Server_Application.CustomerDetails.Domain;
using FluentAssertions;

namespace ESG_Console_Parser_Test
{
    [TestClass]
    public class CustomerDetailsTests
    {
        [TestMethod]
        public void CsvParser_CustomerDetails_ValidInput()
        {
            string customerRef = Guid.NewGuid().ToString();
            string customerName = "John Smith";
            string addressLine1 = "1 Main Street";
            string addressLine2 = string.Empty;
            string town = "London";
            string county = "Greater London";
            string country = "United Kingdom";
            string postCode = "E1 7PT";

            CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode);

            customerData.CustomerRef.Should().Be(customerRef);
            customerData.CustomerName.Should().Be(customerName);
            customerData.AddressLine1.Should().Be(addressLine1);
            customerData.AddressLine2.Should().Be(addressLine2);
            customerData.Town.Should().Be(town);
            customerData.County.Should().Be(county);
            customerData.Country.Should().Be(country);
            customerData.PostCode.Should().Be(postCode);
        }

        [TestMethod]
        public void CsvParser_CustomerDetails_InvalidCustomerRef()
        {
            string customerRef = "not a guid";
            string customerName = "John Smith";
            string addressLine1 = "1 Main Street";
            string addressLine2 = string.Empty;
            string town = "London";
            string county = "Greater London";
            string country = "United Kingdom";
            string postCode = "E1 7PT";

            Action act = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef.ToString(), customerName, addressLine1, addressLine2, town, county, country, postCode);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("CustomerRef is not a valid UUID: {0}", customerRef));

        }

        [TestMethod]
        public void CsvParser_CustomerDetails_InvalidPostCodes()
        {
            string customerRef = Guid.NewGuid().ToString();
            string customerName = "John Smith";
            string addressLine1 = "1 Main Street";
            string addressLine2 = string.Empty;
            string town = "London";
            string county = "Greater London";
            string country = "United Kingdom";
            string postCode = "ABCD 1234";
            string postCode1 = "SW11AA";
            string postCode2 = "W1A 0A";
            string postCode3 = "EC2V7HN";
            string postCode4 = "B338TH";

            Action act = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode);
            };

            Action act1 = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode1);
            };

            Action act2 = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode2);
            };

            Action act3 = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode3);
            };

            Action act4 = () =>
            {
                CustomerDetails customerData = new CustomerDetails(customerRef, customerName, addressLine1, addressLine2, town, county, country, postCode4);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", customerRef, postCode));

            act1.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", customerRef, postCode1));

            act2.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", customerRef, postCode2));

            act3.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", customerRef, postCode3));

            act4.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", customerRef, postCode4));
        }
    }
}