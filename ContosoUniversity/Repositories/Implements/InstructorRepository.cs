using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private SchoolContext schoolContext;

        public InstructorRepository(SchoolContext schoolcontext) : base(schoolcontext)
        {
            this.schoolContext = schoolcontext;
        }
        public new async Task<List<Instructor>> GetAll()
        {

            var listInstructor = await schoolContext.Instructor

                .Include(x => x.OfficeAssignment)
                .ToListAsync();

            return listInstructor;
        }
        public async Task<IEnumerable<Course>> GetCursosByInstructor(int id)
        {
            //  SELECT S.*
            //FROM[dbo].[Enrollment]     E
            // JOIN[dbo].[Course] S ON S.CourseID	=	E.CourseID
            // WHERE E.StudentID = 1;

            var listCursos = await (from courseInstructor in schoolContext.CourseInstructor
                                    join course in schoolContext.Courses on courseInstructor.CourseID equals course.CourseID
                                    where courseInstructor.InstructorID == id
                                    select course).ToListAsync();

            return listCursos;

        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCurso(int id)
        {
            //  SELECT S.*
            //FROM[dbo].[Enrollment]     E
            // JOIN[dbo].[Course] S ON S.CourseID	=	E.CourseID
            // WHERE E.StudentID = 1;

            var listEnrollments = await schoolContext.Enrollments
                         .Include(x => x.Student)
                         .Where(x => x.CourseID == id)
                         .ToListAsync();

            return listEnrollments;

        }

    }
}
