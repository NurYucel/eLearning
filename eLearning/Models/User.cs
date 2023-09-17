using System.ComponentModel.DataAnnotations;
using eLearning.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace eLearning.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public string Role { get; set; }
        
    }


}
