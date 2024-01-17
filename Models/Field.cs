namespace SchoolExams.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
