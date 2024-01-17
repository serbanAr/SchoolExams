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
    public class CreateModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public CreateModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "FullName");
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "CourseName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Enrollment == null || Enrollment == null)
            {
                return Page();
            }
            if (Enrollment.StudentId > 0 && Enrollment.CourseId > 0)
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
            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
