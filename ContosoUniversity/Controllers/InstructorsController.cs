using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using AutoMapper;
using ContosoUniversity.Services;
using ContosoUniversity.DTOs;

namespace ContosoUniversity.Controllers
{
    public class InstructorsController : Controller
    {
        //  private readonly SchoolContext _context;

        private readonly IInstructorService instructorService;

        private readonly IMapper mapper;


        public InstructorsController(IInstructorService instructorService, IMapper mapper)
        {
            this.mapper = mapper;
            this.instructorService = instructorService;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            //return View(await _context.Instructor.ToListAsync());



            if (id != null)
            {
                var data = await instructorService.GetCursosByInstructor(id.Value);

                ViewBag.Courses = data.Select(x => mapper.Map<CourseDTO>(x)).ToList();
            }

            if (courseID != null)
            {
                //var enrollments = await enrollmentService.GetAll();
                var data = await instructorService.GetEnrollmentsByCurso(courseID.Value);

                ViewBag.Enrollments = data.Select(x => mapper.Map<EnrollmentDTO>(x)).ToList();
            }
            var data1 = await instructorService.GetAll();
            //return View(await _studentService.GetAll());
            var listInstructors = data1.Select(x => mapper.Map<InstructorDTO>(x)).ToList();

            return View(listInstructors);
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await instructorService.GetById(id.Value);

            var instructorDTO = mapper.Map<InstructorDTO>(instructor);

            return View(instructorDTO);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorDTO instructorDTO)
        {
            if (ModelState.IsValid)
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Insert(instructor);
                var id = instructor.ID;
                return RedirectToAction(nameof(Index));
            }


            return View(instructorDTO);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await instructorService.GetById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorDTO = mapper.Map<InstructorDTO>(instructor);
            return View(instructorDTO);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InstructorDTO instructorDTO)
        {


            if (ModelState.IsValid)
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Update(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(instructorDTO);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await instructorService.GetById(id.Value);
            var instructorDTO = mapper.Map<InstructorDTO>(instructor);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructorDTO);
        }


        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await instructorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");

            }
        }

        //private bool InstructorExists(int id)
        //{
        //    return _context.Instructor.Any(e => e.ID == id);
        //}
    }
}
