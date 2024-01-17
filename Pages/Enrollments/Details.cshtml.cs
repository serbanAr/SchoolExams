using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Enrollments
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public DetailsModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

      public Enrollment Enrollment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
            }
            return Page();
        }
    }
}
