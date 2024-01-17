using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolExams.Models;

namespace SchoolExams.Data
{
    public class SchoolExamsContext : DbContext
    {
        public SchoolExamsContext (DbContextOptions<SchoolExamsContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolExams.Models.Student> Student { get; set; } = default!;

        public DbSet<SchoolExams.Models.Course>? Course { get; set; }

        public DbSet<SchoolExams.Models.Teacher>? Teacher { get; set; }

        public DbSet<SchoolExams.Models.Enrollment>? Enrollment { get; set; }

        public DbSet<SchoolExams.Models.Field>? Field { get; set; }
    }
}
