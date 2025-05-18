using Microsoft.EntityFrameworkCore;
using LABA3.Models;

namespace LABA3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Mark> Marks => Set<Mark>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentAndCourse> StudentAndCourses => Set<StudentAndCourse>();
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        public DbSet<LABA3.Models.Mark> Mark { get; set; } = default!;
    }
}
