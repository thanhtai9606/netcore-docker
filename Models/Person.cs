using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Person
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntityNavigation { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
        public virtual BusinessEntityContact BusinessEntityContact { get; set; }
    }
}
