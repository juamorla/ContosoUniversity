using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        private IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository) : base(instructorRepository)
        {
            this.instructorRepository = instructorRepository;

        }

        public async Task<IEnumerable<Course>> GetCursosByInstructor(int id)
        {
            return await instructorRepository.GetCursosByInstructor(id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCurso(int id)
        {
            return await instructorRepository.GetEnrollmentsByCurso(id);
        }
    }
}
