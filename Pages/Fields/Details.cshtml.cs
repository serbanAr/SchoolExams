﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Fields
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public DetailsModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

      public Field Field { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Field == null)
            {
                return NotFound();
            }

            var field = await _context.Field.FirstOrDefaultAsync(m => m.Id == id);
            if (field == null)
            {
                return NotFound();
            }
            else 
            {
                Field = field;
            }
            return Page();
        }
    }
}
