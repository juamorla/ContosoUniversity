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
    public class DepartmentsController : Controller
    {
        //private readonly SchoolContext _context;

        private readonly IDepartmentService departmentService;
        private readonly IInstructorService instructorService;
        private readonly IMapper mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper, IInstructorService instructorService)
        {
            this.mapper = mapper;
            this.departmentService = departmentService;
            this.instructorService = instructorService;

        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {

            var data1 = await departmentService.GetAll();
            var listDepartments = data1.Select(x => mapper.Map<DepartmentDTO>(x)).ToList();

            return View(listDepartments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentService.GetById(id.Value);

            var departmentDTO = mapper.Map<DepartmentDTO>(department);
            return View(departmentDTO);
        }

        // GET: Departments/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Instructors = await instructorService.GetAll();
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                departmentDTO.Budget = Convert.ToDecimal(departmentDTO.Budget);
                var department = mapper.Map<Department>(departmentDTO);
                department = await departmentService.Insert(department);
                var id = department.DepartmentID;
                return RedirectToAction(nameof(Index));
            }
            return View(departmentDTO);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentService.GetById(id.Value);
            ViewBag.Instructors = await instructorService.GetAll();
            if (department == null)
            {
                return NotFound();
            }

            var departmentDTO = mapper.Map<DepartmentDTO>(department);
            departmentDTO.Budget = Convert.ToDecimal(departmentDTO.Budget);
            return View(departmentDTO);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentDTO departmentDTO)
        {
            //departmentDTO.Budget = Convert.ToDecimal(departmentDTO.Budget);
            if (ModelState.IsValid)
            {

                var department = mapper.Map<Department>(departmentDTO);
                department = await departmentService.Update(department);
                return RedirectToAction(nameof(Index));
            }
            return View(departmentDTO);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentService.GetById(id.Value);
            var departmentDTO = mapper.Map<DepartmentDTO>(department);
            if (department == null)
            {
                return NotFound();
            }

            return View(departmentDTO);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                await departmentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");

            }
        }

        //    private bool DepartmentExists(int id)
        //    {
        //        return _context.Department.Any(e => e.DepartmentID == id);
        //    }
    }
}
