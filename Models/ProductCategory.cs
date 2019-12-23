using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubCategory = new HashSet<ProductSubCategory>();
        }

        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductSubCategory> ProductSubCategory { get; set; }
    }
}
