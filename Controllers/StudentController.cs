using Microsoft.AspNetCore.Mvc;
using SMS_APDP.Sevices;

namespace SMS_APDP.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        private bool IsStudent()
        {
            return HttpContext.Session.GetString("UserRole") == "Student";
        }

        public async Task<IActionResult> Index()
        {
            if (!IsStudent()) return RedirectToAction("AccessDenied", "Home");

            var userId = HttpContext.Session.GetInt32("UserId"); // Lấy UserId từ Session
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var courses = await _studentService.GetCoursesByStudentIdAsync(userId.Value);
            return View(courses);
        }
    }

}
