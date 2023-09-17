using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLearning.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; } 
        public User User { get; set; }
        public Course Course { get; set; }

    }
}
