using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class BusinessEntity
    {
        public int BusinessEntityId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntityAddress BusinessEntityAddress { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Person Person { get; set; }
    }
}
