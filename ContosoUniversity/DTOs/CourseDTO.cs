using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The   Course Id  is required")]
        [Display(Name = " Course Id")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The title is required")]
        [Display(Name = "title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Credit is required")]
        [Display(Name = "Credit")]
        public int Credits { get; set; }

    }
}
