using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Phone
    {
        public Phone()
        {
            BusinessEntityPhone = new HashSet<BusinessEntityPhone>();
        }

        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityPhone> BusinessEntityPhone { get; set; }
    }
}
