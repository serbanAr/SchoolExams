using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolExams.Data;
using SchoolExams.Models;

namespace SchoolExams.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolExams.Data.SchoolExamsContext _context;

        public IndexModel(SchoolExams.Data.SchoolExamsContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.Include(b=>b.Field).ToListAsync();
            }
        }
    }
}
