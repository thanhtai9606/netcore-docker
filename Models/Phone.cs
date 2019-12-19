using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
