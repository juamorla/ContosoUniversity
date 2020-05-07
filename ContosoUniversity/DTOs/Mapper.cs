using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.DTOs;
using ContosoUniversity.Models;


namespace ContosoUniversity.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
            CreateMap<EnrollmentDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<OfficeAssignmentDTO, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
            CreateMap<InstructorDTO, Instructor>();
            CreateMap<Instructor, InstructorDTO>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<CourseInstructorDTO, CourseInstructor>();
            CreateMap<CourseInstructor, CourseInstructorDTO>();

        }

    }
}
