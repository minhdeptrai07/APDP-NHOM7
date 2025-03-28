using SMS_APDP.Repositories;

namespace SMS_APDP.Sevices
{
    public class FacultyService : IFacultyService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public FacultyService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public Task<string?> GetStudentsByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStudentCourseGradeAsync(int studentCourseId, double grade)
        {
            await _studentCourseRepository.UpdateStudentCourseGradeAsync(studentCourseId, grade);
        }
    }
}
