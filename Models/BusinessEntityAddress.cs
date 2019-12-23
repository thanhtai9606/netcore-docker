using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace acb_app.Models
{
    public partial class BusinessEntityAddress
    {
        
        public int BusinessEntityId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }

        [NotMapped]
        public virtual ContactType ContactType { get; set; }
        [NotMapped]
        public virtual Address Address { get; set; }
    }
}
