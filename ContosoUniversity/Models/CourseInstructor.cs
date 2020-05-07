using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class CourseInstructor
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
    }
}
