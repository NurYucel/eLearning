using eLearning.Data.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eLearning.Models;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Courses)
                .WithOne(course => course.Instructor)
                .HasForeignKey(course => course.InstructorID);

            modelBuilder.Entity<Course>()
                .HasMany(course => course.Assignments)
                .WithOne(assigment => assigment.Course)
                .HasForeignKey(assignment => assignment.CourseID);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Enrollments)
                .WithOne(enrollment => enrollment.User)
                .HasForeignKey(enrollment => enrollment.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany (course => course.Enrollments)
                .WithOne (enrollment => enrollment.Course)
                .HasForeignKey (enrollment => enrollment.CourseID);
                

            base.OnModelCreating (modelBuilder);
        }

        /*public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for testing and development

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Courses)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserID = 1,
                    UserName = "Test",
                    Password = "Test",
                    UserRole = UserRole.ADMIN
                }
            );

            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CourseID = 1,
                    Title = "Sample Course 1",
                    Description = "Desc for sample course 1",
                    InstructorID = 1,
                    Enrollments =
                }
            );

          
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    EnrollmentID = 1,
                    UserID = 1,
                    CourseID = 1
                }
            );

        
        }
        */
    }
}
