using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class CourseInstructorService : GenericService<CourseInstructor>, ICourseInstructorService
    {
        private ICourseInstructorRepository _courseInstructorRepository;

        public CourseInstructorService(ICourseInstructorRepository courseInstructorRepository) : base(courseInstructorRepository)
        {
            _courseInstructorRepository = courseInstructorRepository;
        }
    }
}

