using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace acb_app.Models
{
    public partial class BusinessEntity
    {
        public int BusinessEntityId { get; set; }
        public DateTime ModifiedDate { get; set; }
      //  public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
       public virtual BusinessEntityAddress BusinessEntityAddress { get; set; }
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Person Person { get; set; }
    }
}
