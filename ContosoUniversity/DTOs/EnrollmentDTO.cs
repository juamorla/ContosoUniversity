using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.DTOs
{
    public class EnrollmentDTO
    {

        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "The Course ID is required")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The Student ID  required")]
        [Display(Name = "Student ID")]
        public string StudentID { get; set; }

        public Grade? Grade { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }

    }
}
