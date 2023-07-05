using ESG_Rest_Server_Repository.PTO;
using Microsoft.EntityFrameworkCore;

namespace ESG_Rest_Server_Repository.Context
{
    internal class CustomerDetailsContext : DbContext
    {
        public DbSet<CustomerDetails> CustomerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CustomerInformation"); // Set the in-memory database provider
        }
    }
}
