using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Courses
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
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id","FullName");
            ViewData["FieldId"] = new SelectList(_context.Set<Field>(), "Id", "FieldName");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Course == null || Course == null)
            {
                return Page();
            }

            _context.Course.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
