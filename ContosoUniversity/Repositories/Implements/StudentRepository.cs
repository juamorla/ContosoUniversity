using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepositoy
    {
        private SchoolContext schoolContext;
        public StudentRepository(SchoolContext schoolcontext) : base(schoolcontext)
        {
            this.schoolContext = schoolcontext;
        }


        public async Task<IEnumerable<Course>> GetCursosByStudent(int id)
        {
            //  SELECT S.*
            //FROM[dbo].[Enrollment]     E
            // JOIN[dbo].[Course] S ON S.CourseID	=	E.CourseID
            // WHERE E.StudentID = 1;

            var listCursos = await (from enrollment in schoolContext.Enrollments
                                    join course in schoolContext.Courses on enrollment.CourseID equals course.CourseID
                                    where enrollment.StudentID == id
                                    select course).ToListAsync();

            return listCursos;

        }
    }
}
