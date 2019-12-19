using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ProductSubCatetory
    {
        public int ProductSubCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
