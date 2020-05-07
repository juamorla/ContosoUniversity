using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using ContosoUniversity.DTOs;
using AutoMapper;

namespace ContosoUniversity
{
    public class StudentsController : Controller
    {
        //  private readonly SchoolContext _context;
        private readonly IStudentService _studentService;
        private readonly IMapper mapper;


        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.mapper = mapper;
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                var data = await _studentService.GetCursosByStudent(id.Value);
                ViewBag.Courses = data.Select(x => mapper.Map<CourseDTO>(x)).ToList();
            }
            var data1 = await _studentService.GetAll();
            //return View(await _studentService.GetAll());
            var listStudents = data1.Select(x => mapper.Map<StudentDTO>(x)).ToList();

            return View(listStudents);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (student == null)
            //{
            //    return NotFound();
            //}
            var student = await _studentService.GetById(id.Value);

            var studentDTO = mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {


            if (ModelState.IsValid)
            {
                //var student = new Student
                //{
                //    FirstMidName = studentDTO.FirstMidName,
                //    LastName = studentDTO.LastName,
                //    EnrollmentDate = studentDTO.EnrollmentDate

                //};

                //_context.Add(student)O
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var student = mapper.Map<Student>(studentDTO);
                student = await _studentService.Insert(student);
                var id = student.ID;
                return RedirectToAction(nameof(Index));

            }
            return View(studentDTO);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FindAsync(id);
            var student = await _studentService.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        public async Task<IActionResult> Edit(StudentDTO studentDTO)

        {
            //if (id != student.ID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(student);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!StudentExists(student.ID))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                var student = mapper.Map<Student>(studentDTO);
                student = await _studentService.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDTO);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students
            //    .FirstOrDefaultAsync(m => m.ID == id);

            var student = await _studentService.GetById(id.Value);
            var studentDTO = mapper.Map<StudentDTO>(student);

            if (student == null)
            {
                return NotFound();
            }

            return View(studentDTO);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var student = await _context.Students.FindAsync(id);
            //_context.Students.Remove(student);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            try
            {
                await _studentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");

            }
        }

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.ID == id);
        //}
    }
}