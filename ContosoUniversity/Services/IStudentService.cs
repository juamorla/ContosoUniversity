using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public interface IStudentService : IGenericService<Student>
    {
        Task<IEnumerable<Course>> GetCursosByStudent(int id);

    }
}