using SMS_APDP.DTO;
using SMS_APDP.Models;
using SMS_APDP.Repositories;

namespace SMS_APDP.Sevices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user != null && user.PassWord == password)
            {
                var session = _httpContextAccessor.HttpContext.Session;
                session.SetString("UserId", user.Id.ToString());
                session.SetString("Username", user.UserName);
                session.SetString("Role", user.Role.RoleName);
                session.SetInt32("RoleId", user.RoleId);

                return user;
            }

            return null;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto userDto)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(userDto.UserName);
            if (existingUser != null) return false; // Tài khoản đã tồn tại

            var newUser = new User
            {
                UserName = userDto.UserName,
                PassWord = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // Mã hóa mật khẩu
                Email = userDto.Email,
                FullName = userDto.FullName,
                RoleId = userDto.RoleId,
                CreateDate = DateTime.UtcNow
            };

            return await _userRepository.CreateUserAsync(newUser);
        }
        
        public void Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        
    }
}
