using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductSubCategory ProductSubcategory { get; set; }
        public virtual ProductInventory ProductInventory { get; set; }
        public virtual ProductListPriceHistory ProductListPriceHistory { get; set; }
        public virtual ProductProductPhoto ProductProductPhoto { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
