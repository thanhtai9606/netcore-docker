using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Employee
    {
        public int BusinessEntityId { get; set; }
        public int? NationalIdnumber { get; set; }
        public int LoginId { get; set; }
        public int? Position { get; set; }
        public int? JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public sbyte VacationHours { get; set; }
        public sbyte SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
