using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class BusinessEntityPhone
    {
        public int BusinessEntityId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntityNavigation { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
