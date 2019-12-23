using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace acb_app.Models
{
    public partial class BusinessEntityContact
    {
        
        public int BusinessEntityId { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ContactType ContactType { get; set; }

        [NotMapped]
        public virtual Person Person { get; set; }
    }
}
