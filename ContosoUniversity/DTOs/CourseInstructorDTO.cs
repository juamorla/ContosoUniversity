using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class CourseInstructorDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Course Id required")]
        [Display(Name = "Course Id")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The Instructor Id required")]
        [Display(Name = "Instructor Id")]
        public int InstructorID { get; set; }
    }
}
