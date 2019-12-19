using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Vendor
    {
        public int BusinessEntityId { get; set; }
        public int AccountNumber { get; set; }
        public int Name { get; set; }
        public int ActiveFlag { get; set; }
        public int PreferredVendorStatus { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
