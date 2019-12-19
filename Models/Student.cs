using System;
using System.Collections.Generic;

namespace acb_app.Models{
     public class Student
    {
        public int ID { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
       
    }
}