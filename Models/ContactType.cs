using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ContactType
    {
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
