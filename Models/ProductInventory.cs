using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ProductInventory
    {
        public int ProductId { get; set; }
        public int? LocationId { get; set; }
        public int? Shelf { get; set; }
        public int? Bin { get; set; }
        public short Quantity { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
