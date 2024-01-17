using System;
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
    public class IndexModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public IndexModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

        public IList<Field> Field { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Field != null)
            {
                Field = await _context.Field.ToListAsync();
            }
        }
    }
}
