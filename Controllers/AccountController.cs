using Microsoft.AspNetCore.Mvc;
using SMS_APDP.DTO;
using SMS_APDP.Models;
using SMS_APDP.Repositories;
using SMS_APDP.Sevices;

namespace SMS_APDP.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _authService.LoginAsync(username, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("RedirectUserByRole");
            }

            ViewBag.Error = "Incorrect username or password!";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto )
        {
            if(userRegisterDto == null)
            {
                return BadRequest();
            }
            userRegisterDto.RoleId = 1;
            var register = await _authService.RegisterAsync(userRegisterDto);
            if (register)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Incorrect register!";
            return View();
        }

        public IActionResult Logout()
        { 
            _authService.Logout();
            return RedirectToAction("Login");
        }

        public IActionResult RedirectUserByRole()
        {
            int? roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId == null)
            {
                return RedirectToAction("Login");
            }

            switch(roleId)
            {
                case 1:
                    HttpContext.Session.SetString("UserRole", "Student");
                    return RedirectToAction("Index", "Student");
                case 2:
                    HttpContext.Session.SetString("UserRole", "Admin");
                    return RedirectToAction("Create", "Admin");
                case 3:
                    HttpContext.Session.SetString("UserRole", "Faculty");
                    return RedirectToAction("GradeStudent", "Faculty");
                default:
                    return RedirectToAction("AccessDenied", "Home");
            }
        }
    }

}


