using Microsoft.EntityFrameworkCore;
using SMS_APDP.DataContext;
using SMS_APDP.Models;

namespace SMS_APDP.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourse>> GetCoursesByStudentIdAsync(int studentId)
        {
            return await _context.StudentCourses
                .Include(sc => sc.Course)
                .Where(sc => sc.StudentId == studentId)
                .ToListAsync();
        }

        public async Task AddStudentCourseAsync(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentCourseGradeAsync(int studentCourseId, double grade)
        {
            var studentCourse = await _context.StudentCourses.FindAsync(studentCourseId);
            if (studentCourse != null)
            {
                studentCourse.Grade = grade;
                _context.StudentCourses.Update(studentCourse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
