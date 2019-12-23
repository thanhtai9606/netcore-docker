using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class SaleOrderHeader
    {
        public int SalesOrderId { get; set; }
        public sbyte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public sbyte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public int SalesPersonId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual SalesOrderDetail SalesOrder { get; set; }
        public virtual SalesOrderDetail SalesOrderDetail { get; set; }
    }
}
