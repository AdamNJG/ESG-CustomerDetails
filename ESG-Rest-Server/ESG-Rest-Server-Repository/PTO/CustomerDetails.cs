using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESG_Rest_Server_Repository.PTO
{
    public class CustomerDetails
    {
        [Key]
        [Column("Customer Reference")]
        public Guid CustomerRef { get; set; }
        [Column("Customer Name")]
        public string CustomerName { get; set; }
        [Column("Address Line 1")]
        public string AddressLine1 { get; set; }
        [Column("Address Line 2")]
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        [Column("Post Code")]
        public string PostCode { get; set; }
    }
}