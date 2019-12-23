using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class BusinessEntityContact
    {
        public int BusinessEntityId { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person BusinessEntity1 { get; set; }
        public virtual BusinessEntity BusinessEntityNavigation { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
