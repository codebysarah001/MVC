using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mini_school_system.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }

}