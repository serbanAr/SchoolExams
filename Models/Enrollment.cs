﻿using System.ComponentModel.DataAnnotations;

namespace SchoolExams.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
