using ESG_Rest_Server_Application.CustomerDetails;
using ESG_Rest_Server_Application.CustomerDetails.Domain;
using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Test.Helpers;
using ESG_Rest_Server_Test.TestDoubles;
using FluentAssertions;

namespace ESG_Rest_Server_Test
{
    [TestClass]
    public class CustomerDetailsServiceTest
    {
        [TestMethod]
        public void CustomerDetailsService_StoreCustomerDetails_InDtoMatchesOutReturnsTrue()
        {
            CustomerDetailsStorage mockStorage = new CustomerDetailsStorage();
            CustomerDetailsServiceLoggerSpy loggerSpy = new CustomerDetailsServiceLoggerSpy();

            CustomerDetailsService customerDetailsService = new CustomerDetailsService(mockStorage, loggerSpy);

            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();

            CreateResult result = customerDetailsService.StoreCustomerDetails(inDto);

            CustomerDetailsOutDto outDto = mockStorage.CustomerDetails.First();

            result.Success.Should().Be(true);
            result.Message.Should().Be(String.Empty);

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
        public void CustomerDetailsService_ExceptionThrown_EntityFrameworkErrorLoggedReturnsFalse()
        {
            ErroringDetailsStorage mockStorage = new ErroringDetailsStorage();
            CustomerDetailsServiceLoggerSpy loggerSpy = new CustomerDetailsServiceLoggerSpy();

            CustomerDetailsService customerDetailsService = new CustomerDetailsService(mockStorage, loggerSpy);

            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();

            CreateResult result = customerDetailsService.StoreCustomerDetails(inDto);

            result.Success.Should().Be(true);
            result.Message.Should().Be("Exception of type 'Microsoft.EntityFrameworkCore.DbUpdateException' was thrown.");

            loggerSpy.LogEntries.Count.Should().Be(1);
            loggerSpy.LogEntries.First().Should().Be("Exception of type 'Microsoft.EntityFrameworkCore.DbUpdateException' was thrown.");
        }

        [TestMethod]
        public async Task CustomerDetailsService_StoreCustomerDetails_RetreiveDetails()
        {
            CustomerDetailsStorage mockStorage = new CustomerDetailsStorage();
            CustomerDetailsServiceLoggerSpy loggerSpy = new CustomerDetailsServiceLoggerSpy();

            CustomerDetailsService customerDetailsService = new CustomerDetailsService(mockStorage, loggerSpy);

            CustomerDetailsInDto inDto = CustomerDetailsTestHelper.CreateTestCustomerData();

            customerDetailsService.StoreCustomerDetails(inDto);

            CustomerDetailsOutDto outDto = await customerDetailsService.GetCustomerDetails(Guid.Parse(inDto.CustomerRef));

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
        public void CustomerDetailsService_RecordNotFound_EntityFrameworkErrorLogged()
        {
            CustomerDetailsStorage mockStorage = new CustomerDetailsStorage();
            CustomerDetailsServiceLoggerSpy loggerSpy = new CustomerDetailsServiceLoggerSpy();

            CustomerDetailsService customerDetailsService = new CustomerDetailsService(mockStorage, loggerSpy);

            CustomerDetailsTestHelper.CreateTestCustomerData();

            customerDetailsService.GetCustomerDetails(Guid.NewGuid());

            loggerSpy.LogEntries.Count.Should().Be(1);
            loggerSpy.LogEntries.First().Should().Be("Exception of type 'Microsoft.EntityFrameworkCore.DbUpdateException' was thrown.");
        }
    }
}