using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace acb_app.Models
{
    public partial class Employee
    {
        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        public string LoginId { get; set; }
        public string Position { get; set; }
        public string JobTitle { get; set; }
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
