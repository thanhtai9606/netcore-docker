using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ProductSubCatetory
    {
        public ProductSubCatetory()
        {
            Product = new HashSet<Product>();
        }

        public int ProductSubCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
