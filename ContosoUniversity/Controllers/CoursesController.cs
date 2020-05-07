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
    public class CoursesController : Controller
    {
        //private readonly SchoolContext _context;
        private readonly ICourseService _courseService;
        private readonly IMapper mapper;


        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            //_context = context;
            _courseService = courseService;

            this.mapper = mapper;
        }

        // GET: Courses
        public async Task<IActionResult> Index(int? id)
        {
            //scaffol
            //return View(await _context.Courses.ToListAsync());

            //return View(await _courseService.GetAll());

            //return View(await _studentService.GetAll());

            //var data = await _courseService.GetAll();
            //var listCourses = data.Select(x => mapper.Map<CourseDTO>(x)).ToList();
            //return View(listCourses);

            if (id != null)
            {
                var data = await _courseService.GetStudentsByCourse(id.Value);
                ViewBag.Students = data.Select(x => mapper.Map<StudentDTO>(x)).ToList();
            }

            var data1 = await _courseService.GetAll();
            var listCourses = data1.Select(x => mapper.Map<CourseDTO>(x)).ToList();
            return View(listCourses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var course = await _context.Courses
            //    .FirstOrDefaultAsync(m => m.CourseID == id);
            //if (course == null)
            //{
            //    return NotFound();
            //}
            var course = await _courseService.GetById(id.Value);
            var coursetDTO = mapper.Map<CourseDTO>(course);

            return View(coursetDTO);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CourseID,Title,Credits")] Course course)
        public async Task<IActionResult> Create(CourseDTO courseDTO)

        {
            if (ModelState.IsValid)
            {
                //_context.Add(course);
                //await _context.SaveChangesAsync();
                //await _courseService.Insert(course);

                var course = mapper.Map<Course>(courseDTO);
                course = await _courseService.Insert(course);

                return RedirectToAction(nameof(Index));
            }
            return View(courseDTO);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var course = await _context.Courses.FindAsync(id);
            //if (course == null)
            //{
            //    return NotFound();
            //}
            var course = await _courseService.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            var courseDTO = mapper.Map<CourseDTO>(course);
            return View(courseDTO);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CourseID,Title,Credits")] Course course)
        public async Task<IActionResult> Edit(int id, CourseDTO courseDTO)

        {
            if (id != courseDTO.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(course);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CourseExists(course.CourseID))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                var course = mapper.Map<Course>(courseDTO);
                course = await _courseService.Update(course);
                return RedirectToAction(nameof(Index));
            }
            return View(courseDTO);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var course = await _context.Courses
            //    .FirstOrDefaultAsync(m => m.CourseID == id);
            //if (course == null)
            //{
            //    return NotFound();
            //}
            var course = await _courseService.GetById(id.Value);
            var courseDTO = mapper.Map<CourseDTO>(course);
            if (course == null)
            {
                return NotFound();
            }
            return View(courseDTO);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var course = await _context.Courses.FindAsync(id);
            //_context.Courses.Remove(course);
            //await _context.SaveChangesAsync();


            //await _courseService.Delete(id);

            // return RedirectToAction(nameof(Index));

            //new implement
            try
            {
                await _courseService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");

            }


        }
        //**********
        //private bool CourseExists(int id)
        //{
        //    return _context.Courses.Any(e => e.CourseID == id);
        //}
    }
}
