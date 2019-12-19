using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class PurchaseOrderDetail
    {
        public int PurchaseOrderId { get; set; }
        public int PurchaseOrderDetailId { get; set; }
        public DateTime DueDate { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int ReceivedQty { get; set; }
        public int RejectedQty { get; set; }
        public int StockedQty { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
