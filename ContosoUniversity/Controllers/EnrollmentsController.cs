using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService enrollmentService;
        private IStudentService studentService;
        private ICourseService courseService;



        public EnrollmentsController(IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService)
        {
            this.enrollmentService = enrollmentService;
            this.studentService = studentService;
            this.courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var listEnrollments = await enrollmentService.GetAll();

            return View(listEnrollments);

        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Courses = await courseService.GetAll();
            ViewBag.Students = await studentService.GetAll();

            //List<string> listGrades = new  List<string>{ "A", "B", "C", "D", "E", "F" };

            //ViewBag.Grades = listGrades;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Enrollment model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            await enrollmentService.Insert(model);
            return RedirectToAction("Index");
        }


    }
}