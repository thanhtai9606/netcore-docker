using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int WardId { get; set; }
        public string PostalCode { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
