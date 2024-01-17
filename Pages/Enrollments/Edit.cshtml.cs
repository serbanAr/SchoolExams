using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public EditModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "FullName");
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "CourseName");

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            Enrollment = enrollment;
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Enrollment != null && Enrollment.StudentId > 0 && Enrollment.CourseId > 0)
            {
                var student = await _context.Set<Student>()
                    .Include(s => s.Field)
                    .FirstOrDefaultAsync(s => s.Id == Enrollment.StudentId);

                var course = await _context.Set<Course>()
                    .Include(c => c.Field)
                    .FirstOrDefaultAsync(c => c.Id == Enrollment.CourseId);

                if (student != null && course != null && student.FieldId != course.FieldId)
                {
                    ModelState.AddModelError(string.Empty, "Student can only enroll in courses from the same field.");
                    return Page();
                }

                if (student.Semester != course.Semester)
                {
                    ModelState.AddModelError(string.Empty, "Student can only enroll in courses from the same semester.");
                    return Page();
                }
            }
            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int id)
        {
          return (_context.Enrollment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
