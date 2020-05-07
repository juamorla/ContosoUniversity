using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {

        private SchoolContext schoolContext;

        public EnrollmentRepository(SchoolContext schoolcontext) : base(schoolcontext)
        {
            this.schoolContext = schoolcontext;
        }

        public new async Task<List<Enrollment>> GetAll()
        {

            var listEnrollments = await schoolContext.Enrollments
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();

            //var listEnrollments = await (from enrollments in schoolContext.Enrollments
            //                             join course in schoolContext.Courses on enrollments.CourseID equals course.CourseID
            //                             join student in schoolContext.Students on enrollments.StudentID equals student.ID
            //                             select enrollments).ToListAsync();


            //return await schoolContext.Enrollments.ToListAsync();
            //throw new NotImplementedException();

            return listEnrollments;
        }
    }
}
