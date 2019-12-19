using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class PurchaseOrderId
    {
        public int PurchaseOrderId1 { get; set; }
        public int RevisionNumber { get; set; }
        public sbyte Status { get; set; }
        public int EmployeeId { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
