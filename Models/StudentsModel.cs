using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMVC.Models
{
    public class StudentsModel
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}