﻿namespace LABA3.Models
{
    public class StudentAndCourse
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
