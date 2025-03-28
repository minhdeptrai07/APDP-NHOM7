using Microsoft.AspNetCore.Mvc;
using SMS_APDP.Sevices;

namespace SMS_APDP.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        private bool IsFaculty()
        {
            return HttpContext.Session.GetString("UserRole") == "Faculty";
        }

        
        public async Task<IActionResult> GradeStudent(int courseId)
        {
            if (!IsFaculty()) return RedirectToAction("AccessDenied", "Home");

            var students = await _facultyService.GetStudentsByCourseIdAsync(courseId);
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGrade(int studentCourseId, double grade)
        {
            if (!IsFaculty()) return RedirectToAction("AccessDenied", "Home");

            await _facultyService.UpdateStudentCourseGradeAsync(studentCourseId, grade);
            return RedirectToAction(nameof(GradeStudent), new { courseId = studentCourseId });
        }
    }
}
