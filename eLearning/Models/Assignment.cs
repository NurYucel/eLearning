using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLearning.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Course Course { get; set; }

    }
}
