using Microsoft.EntityFrameworkCore;
using Lab7_StudentRegistration.Models;

namespace Lab7_StudentRegistration.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<StuMajor> StuMajors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student table
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Stu_ID);

            // Configure StuMajor table
            modelBuilder.Entity<StuMajor>()
                .HasKey(m => m.Id);
        }
    }
}