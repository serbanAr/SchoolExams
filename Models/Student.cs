using System.ComponentModel.DataAnnotations;

namespace SchoolExams.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return Lastname + " " + Firstname;
            }
        }
        [Range(1, 6, ErrorMessage = "Year must be between 1 and 3.")]
        public int Semester { get; set; }
        public int? FieldId { get; set; }
        public Field? Field { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
