using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LABA3;
using LABA3.Models;

namespace LABA3.Controllers
{
    public class StudentAndCoursesController : Controller
    {
        private readonly ApplicationContext _context;

        public StudentAndCoursesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: StudentAndCourses
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.StudentAndCourses.Include(s => s.Course).Include(s => s.Student);
            return View(await applicationContext.ToListAsync());
        }

        // GET: StudentAndCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAndCourse = await _context.StudentAndCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentAndCourse == null)
            {
                return NotFound();
            }

            return View(studentAndCourse);
        }

        // GET: StudentAndCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: StudentAndCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId")] StudentAndCourse studentAndCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAndCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentAndCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentAndCourse.StudentId);
            return View(studentAndCourse);
        }

        // GET: StudentAndCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAndCourse = await _context.StudentAndCourses.FindAsync(id);
            if (studentAndCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentAndCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentAndCourse.StudentId);
            return View(studentAndCourse);
        }

        // POST: StudentAndCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId")] StudentAndCourse studentAndCourse)
        {
            if (id != studentAndCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAndCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAndCourseExists(studentAndCourse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentAndCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", studentAndCourse.StudentId);
            return View(studentAndCourse);
        }

        // GET: StudentAndCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAndCourse = await _context.StudentAndCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentAndCourse == null)
            {
                return NotFound();
            }

            return View(studentAndCourse);
        }

        // POST: StudentAndCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentAndCourse = await _context.StudentAndCourses.FindAsync(id);
            if (studentAndCourse != null)
            {
                _context.StudentAndCourses.Remove(studentAndCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAndCourseExists(int id)
        {
            return _context.StudentAndCourses.Any(e => e.Id == id);
        }
    }
}
