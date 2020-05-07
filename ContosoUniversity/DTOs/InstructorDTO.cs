using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Firts name  required")]
        [Display(Name = "Firts Name")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "The Hire Date  is required")]
        [Display(Name = "Hire date")]
        public DateTime Hiredate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }


        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);

            }
        }
    }
}
