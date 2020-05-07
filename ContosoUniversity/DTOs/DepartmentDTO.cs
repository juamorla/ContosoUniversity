using System;
using System.ComponentModel.DataAnnotations;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Budget is required")]
        [Display(Name = "Budget")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "The Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The Instructor Id is required")]
        [Display(Name = "Instructor Id")]
        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }
    }
}

