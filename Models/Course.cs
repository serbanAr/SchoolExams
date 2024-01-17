namespace SchoolExams.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Semester { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set;}
        public int? FieldId { get; set; }
        public Field? Field { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set;}
    }
}
