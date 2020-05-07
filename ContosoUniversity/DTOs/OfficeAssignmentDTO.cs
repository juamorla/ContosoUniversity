using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Required(ErrorMessage = "The Instructor Id is required")]
        [Display(Name = "Instructor Id")]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "The Location is required")]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
