using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories
{
    public interface IStudentRepositoy : IGenericRepository<Student>
    {
        Task<IEnumerable<Course>> GetCursosByStudent(int id);

    }
}