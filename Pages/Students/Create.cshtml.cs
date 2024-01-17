﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Students
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
            ViewData["FieldId"] = new SelectList(_context.Set<Field>(), "Id", "FieldName");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Student == null || Student == null)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
