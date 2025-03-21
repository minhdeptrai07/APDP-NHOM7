using Microsoft.AspNetCore.Mvc;
using SMS_APDP.Models;
using SMS_APDP.Repositories;

namespace SMS_APDP.Controllers
{
        public class UserController : Controller
        {
            private readonly IUserRepository _userRepository;

            public UserController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(User user)
            {
                string username = user.Username;
                string password = user.Password;

                var _user = _userRepository.GetUserByUsernameAndPassword(username, password);

                if (_user != null)
                {
                    ViewBag.Username = _user.Username;
                    ViewBag.IsLogin = true;
                    HttpContext.Session.SetString("Username", username);
                    HttpContext.Session.SetString("Fullname", _user.Fullname);
                    HttpContext.Session.SetInt32("IsLogin", 1);
                }
                return View();
            }

            [HttpPost]
            public ActionResult Logout()
            {

                HttpContext.Session.Remove("Username");
                HttpContext.Session.Remove("Fullname");
                HttpContext.Session.Remove("IsLogin");

                return View("User/Login");
            }

            [HttpGet]
            public ActionResult Register()
            {
                return View();
            }
        }
    }

