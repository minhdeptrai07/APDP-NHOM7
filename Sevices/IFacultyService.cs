namespace SMS_APDP.Sevices
{
    public interface IFacultyService
    {
        Task<string?> GetStudentsByCourseIdAsync(int courseId);
        Task UpdateStudentCourseGradeAsync(int studentCourseId, double grade);
    }
}
