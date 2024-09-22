using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace mini_school_system.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }

}