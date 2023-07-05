using ESG_Rest_Server_Application.CustomerDetails.Domain;
using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Test.Helpers;
using FluentAssertions;

namespace ESG_Rest_Server_Test
{
    [TestClass]
    public class CustomerDetailsTests
    {
        /*
        [TestMethod]
        public void CusomterDetails_ParseInDto_ValidInput()
        {
            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();

            CustomerData customerData = new CustomerData(inDto);

            customerData.CustomerRef.Should().Be(Guid.Parse(inDto.CustomerRef));
            customerData.CustomerName.Should().Be(inDto.CustomerName);
            customerData.AddressLine1.Should().Be(inDto.AddressLine1);
            customerData.AddressLine2.Should().Be(inDto.AddressLine2);
            customerData.Town.Should().Be(inDto.Town);
            customerData.County.Should().Be(inDto.County);
            customerData.Country.Should().Be(inDto.Country);
            customerData.PostCode.Should().Be(inDto.PostCode);
        }*/

        [TestMethod]
        public void CusomterDetails_GetOutDto_ValidInput()
        {
            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();

            CustomerData customerData = new CustomerData(inDto);

            CustomerDetailsOutDto outDto = customerData.GetDto();

            outDto.CustomerRef.Should().Be(Guid.Parse(inDto.CustomerRef));
            outDto.CustomerName.Should().Be(inDto.CustomerName);
            outDto.AddressLine1.Should().Be(inDto.AddressLine1);
            outDto.AddressLine2.Should().Be(inDto.AddressLine2);
            outDto.Town.Should().Be(inDto.Town);
            outDto.County.Should().Be(inDto.County);
            outDto.Country.Should().Be(inDto.Country);
            outDto.PostCode.Should().Be(inDto.PostCode);
        }

        [TestMethod]
        public void CusomterDetails_ParseInDto_InvalidCustomerRef()
        {
            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto.CustomerRef = "not a guid";

            Action act = () =>
            {
                CustomerData customerData = new CustomerData(inDto);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("CustomerRef is not a valid UUID: {0}", inDto.CustomerRef));

        }

        [TestMethod]
        public void CusomterDetails_ParseInDto_InvalidPostCodes()
        {
            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto.PostCode = "ABCD 1234";
            CustomerDetailsInDto inDto2 = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto2.PostCode = "SW11AA";
            CustomerDetailsInDto inDto3 = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto3.PostCode = "W1A 0A";
            CustomerDetailsInDto inDto4 = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto4.PostCode = "EC2V7HN";
            CustomerDetailsInDto inDto5 = CustomerDetailsTestHelper.CreateTestCustomerData();
            inDto5.PostCode = "B338TH";

            Action act = () =>
            {
                CustomerData customerData = new CustomerData(inDto);
            };

            Action act1 = () =>
            {
                CustomerData customerData = new CustomerData(inDto2);
            };

            Action act2 = () =>
            {
                CustomerData customerData = new CustomerData(inDto3);
            };

            Action act3 = () =>
            {
                CustomerData customerData = new CustomerData(inDto4);
            };

            Action act4 = () =>
            {
                CustomerData customerData = new CustomerData(inDto5);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", inDto.CustomerRef, inDto.PostCode));

            act1.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", inDto2.CustomerRef, inDto2.PostCode));

            act2.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", inDto3.CustomerRef, inDto3.PostCode));

            act3.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", inDto4.CustomerRef, inDto4.PostCode));

            act4.Should().Throw<ArgumentException>()
                .WithMessage(String.Format("PostCode for customer {0} is not valid: {1}", inDto5.CustomerRef, inDto5.PostCode));
        }
    }
}