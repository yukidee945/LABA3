namespace LABA3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
