using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Fields
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
            return Page();
        }

        [BindProperty]
        public Field Field { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Field == null || Field == null)
            {
                return Page();
            }

            _context.Field.Add(Field);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
