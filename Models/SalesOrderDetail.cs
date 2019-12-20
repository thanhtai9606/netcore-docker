using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class SalesOrderDetail
    {
        public int SalesOrderId { get; set; }
        public int SalesOrderDetailId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public int? SpecialOfferId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual SaleOrderHeader SalesOrder { get; set; }
        public virtual SaleOrderHeader SaleOrderHeader { get; set; }
    }
}
