using System.ComponentModel.DataAnnotations;

namespace SMS_APDP.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
