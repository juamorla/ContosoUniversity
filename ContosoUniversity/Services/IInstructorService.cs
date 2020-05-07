using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public interface IInstructorService : IGenericService<Instructor>
    {
        Task<IEnumerable<Course>> GetCursosByInstructor(int id);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCurso(int id);


    }
}
