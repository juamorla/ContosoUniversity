using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;


namespace ContosoUniversity.Services
{
    public interface ICourseService : IGenericService<Course>
    {

        Task<IEnumerable<Student>> GetStudentsByCourse(int id);
    }
}