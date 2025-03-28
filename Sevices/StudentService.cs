using SMS_APDP.Models;
using SMS_APDP.Repositories;

namespace SMS_APDP.Sevices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public async Task<IEnumerable<StudentCourse>> GetCoursesByStudentIdAsync(int studentId)
        {
            return await _studentCourseRepository.GetCoursesByStudentIdAsync(studentId);
        }
    }
}
