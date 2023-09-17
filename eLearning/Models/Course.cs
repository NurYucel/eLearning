using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eLearning.Data.Enum;

namespace eLearning.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorID { get; set; }
        public String Category { get; set; }
        public int EnrollmentCount { get; set; }
        public string ImageURL { get; set; }
        public User Instructor { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        
    }
}
