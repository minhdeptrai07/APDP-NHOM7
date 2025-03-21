using System.ComponentModel.DataAnnotations;

namespace SMS_APDP.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Grade { get; set; }
        public virtual User? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
