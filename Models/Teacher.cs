using System.ComponentModel.DataAnnotations;

namespace SchoolExams.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        [Display(Name = "TeacherName")]
        public string FullName
        {
            get
            {
                return Lastname + " " + Firstname;
            }
        }
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone must start with 0 and have a total of 10 digits.")]
        public string phone { get; set; }
        public ICollection<Course>? Courses { get; set;}
    }
}
