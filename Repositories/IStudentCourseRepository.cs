using SMS_APDP.Models;

namespace SMS_APDP.Repositories
{
    public interface IStudentCourseRepository
    {
        Task<IEnumerable<StudentCourse>> GetCoursesByStudentIdAsync(int studentId);
        Task AddStudentCourseAsync(StudentCourse studentCourse);
        Task UpdateStudentCourseGradeAsync(int studentCourseId, double grade);
    }
}
