using SMS_APDP.Models;

namespace SMS_APDP.Sevices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentCourse>> GetCoursesByStudentIdAsync(int studentId);
    }
}
