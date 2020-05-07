using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepositoy studentRepository;

        public StudentService(IStudentRepositoy studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;

        }


        public async Task<IEnumerable<Course>> GetCursosByStudent(int id)
        {

            return await studentRepository.GetCursosByStudent(id);
            //throw new NotImplementedException();
        }
    }
}

