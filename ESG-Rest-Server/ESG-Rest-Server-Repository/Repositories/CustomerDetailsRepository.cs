using ESG_Rest_Server_Application.CustomerDetails.Dto;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;
using ESG_Rest_Server_Repository.Context;
using ESG_Rest_Server_Repository.PTO;
using Microsoft.EntityFrameworkCore;

namespace ESG_Rest_Server_Repository.Repositories
{
    public class CustomerDetailsRepository : ICustomerDetailsStorage
    {
        public Task<CustomerDetailsOutDto> GetCustomer(Guid customerId)
        {
            CustomerDetails pto;
            using (CustomerDetailsContext context = new CustomerDetailsContext())
            {
                pto = context.CustomerDetails.FirstOrDefault(c => c.CustomerRef == customerId);
            }

            if (pto == null)
            {
                throw new DbUpdateException("Customer could not be found");
            }

            return Task.FromResult(new CustomerDetailsOutDto()
            {
                CustomerRef = pto.CustomerRef,
                CustomerName = pto.CustomerName,
                AddressLine1 = pto.AddressLine1,
                AddressLine2 = pto.AddressLine2,
                Town = pto.Town,
                County = pto.County,
                Country = pto.Country,
                PostCode = pto.PostCode
            });
        }

        public void StoreCustomerDetails(CustomerDetailsOutDto details)
        {
            using (CustomerDetailsContext context = new CustomerDetailsContext())
            {
                context.Add(new CustomerDetails()
                {
                    CustomerRef = details.CustomerRef,
                    CustomerName = details.CustomerName,
                    AddressLine1 = details.AddressLine1,
                    AddressLine2 = details.AddressLine2,
                    Town = details.Town,
                    County = details.County,
                    Country = details.Country,
                    PostCode = details.PostCode
                });

                context.SaveChanges();
            }
        }
    }
}
