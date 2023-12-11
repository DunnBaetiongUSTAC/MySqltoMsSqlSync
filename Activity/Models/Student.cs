using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }

    }
}