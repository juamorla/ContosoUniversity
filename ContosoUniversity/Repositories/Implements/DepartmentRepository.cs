using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Repositories.Implements
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private SchoolContext _schoolContext;
        public DepartmentRepository(SchoolContext SchoolContext) : base(SchoolContext)
        {
            _schoolContext = SchoolContext;
        }
        public new async Task<List<Department>> GetAll()
        {
            var listDepartment = await _schoolContext.Department
                .Include(x => x.Instructor)
                .ToListAsync();

            return listDepartment;
        }
    }
}
