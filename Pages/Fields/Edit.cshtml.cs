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

namespace SchoolExams.Pages.Fields
{
    public class EditModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public EditModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Field Field { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Field == null)
            {
                return NotFound();
            }

            var field =  await _context.Field.FirstOrDefaultAsync(m => m.Id == id);
            if (field == null)
            {
                return NotFound();
            }
            Field = field;
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

            _context.Attach(Field).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldExists(Field.Id))
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

        private bool FieldExists(int id)
        {
          return (_context.Field?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
